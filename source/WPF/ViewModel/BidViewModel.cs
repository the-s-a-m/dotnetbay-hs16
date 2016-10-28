using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using WPF.Command;

namespace WPF.ViewModel
{
    public class BidViewModel : ViewModelBase
    {
        public AuctionService AuctionService { get; set; }
        public Auction Auction { get; set; }
        public double Amount { get; set; }

        public BidViewModel(AuctionService auctionService, Auction auction)
        {
            AuctionService = auctionService;
            Auction = auction;
            Amount = auction.CurrentPrice + 1;
        }

        void BidExecute() => AuctionService.PlaceBid(Auction, Amount);
        private bool CanBid() => true;
        public ICommand BidCommand => new RelayCommand<BidViewModel>(x => BidExecute(), x => CanBid());



    }
}
