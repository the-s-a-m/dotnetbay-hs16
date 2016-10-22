using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using Microsoft.Win32;

namespace WPF.dialogs
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public AuctionService AuctionService { get; private set; }
        public IMemberService MemberService { get; private set; }
        public Auction Auction { get; set; } = new Auction();
        public string ImagePath { get; set; } = "";

        public SellView()
        {
            InitializeComponent();
            DataContext = this;

            var app = (App)Application.Current;
            MemberService = new SimpleMemberService(app.MainRepository);
            AuctionService = new AuctionService(app.MainRepository, MemberService);

            Auction.StartDateTimeUtc = DateTime.Now;
            Auction.EndDateTimeUtc = DateTime.Now.AddDays(1);
        }

        private void Add_Image_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
                Auction.Image = File.ReadAllBytes(ImagePath);
            }
        }

        private void Save_Action_Click(object sender, RoutedEventArgs e)
        {
            Auction.Seller = MemberService.GetCurrentMember();
            Auction.IsClosed = false;
            Auction.IsRunning = true;
            AuctionService.Save(Auction);
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
