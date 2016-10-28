using System.Windows;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window, IClosable
    {
        public BidView(AuctionService auctionService, Auction auction)
        {
            InitializeComponent();
            DataContext = new BidViewModel(auctionService, auction);
        }
    }
}
