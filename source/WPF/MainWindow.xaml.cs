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
            var app = (App)Application.Current;

            AuctionService = new AuctionService(app.MainRepository, new SimpleMemberService(app.MainRepository));

            Auctions = new ObservableCollection<Auction>(AuctionService.GetAll());

        }

    }
}
