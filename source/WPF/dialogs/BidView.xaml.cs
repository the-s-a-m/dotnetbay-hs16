using System;
using System.Collections.Generic;
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

namespace WPF.dialogs
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        private readonly AuctionService actionService;
        public Auction Auction { get; set; }
        public double Amount { get; set; }
        public BidView(AuctionService actionService, Auction auction)
        {
            InitializeComponent();
            this.actionService = actionService;
            Auction = auction;
            Amount = auction.CurrentPrice + 1;
        }

        private void Bid_Button_Click(object sender, RoutedEventArgs e)
        {
            actionService.PlaceBid(Auction, Amount);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
