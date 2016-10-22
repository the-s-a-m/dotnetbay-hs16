using DotNetBay.Core;
using DotNetBay.Data.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.dialogs;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Auction> Auctions { get; private set; }
        public AuctionService AuctionService { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var app = Application.Current as App;
            AuctionService = new AuctionService(app.MainRepository, new SimpleMemberService(app.MainRepository));

            Auctions = new ObservableCollection<Auction>(AuctionService.GetAll());

        }

        private void SellButtonClick(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog(); // Blocking 
            Auctions = new ObservableCollection<Auction>(AuctionService.GetAll());
        }

        private void Place_Bid_Click(object sender, RoutedEventArgs e)
        {
            var auctionId = ((Button)sender).Tag;
            Console.WriteLine(auctionId);
            var auction = AuctionService.GetById(Convert.ToInt64(auctionId));
            Console.WriteLine(auction);
            var bidView = new BidView(AuctionService, auction);
            bidView.ShowDialog();
            Auctions = new ObservableCollection<Auction>(AuctionService.GetAll());
        }
    }
}
