using System;
using System.Windows.Controls;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using WPF.Command;
using WPF.View;

namespace WPF.ViewModel
{
    public class AuctionViewModel : ViewModelBase
    {
        public AuctionService AuctionService { get; set; }
        public Auction Auction { get; set; }

        public AuctionViewModel(AuctionService auctionService, Auction auction)
        {
            AuctionService = auctionService;
            Auction = auction;
        }

        void ShowBidViewExecute()
        {
            var bidView = new BidView(AuctionService, Auction);
            bidView.ShowDialog();
            RaisePropertyChanged("Auction");
        }
        private bool CanShowBidView() => true;
        public ICommand BidCommand => new RelayCommand<AuctionViewModel>(x => ShowBidViewExecute(), x => CanShowBidView());
    }
}
