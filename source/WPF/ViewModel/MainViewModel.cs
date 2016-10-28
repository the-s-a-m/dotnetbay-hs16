using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using WPF.Command;
using WPF.View;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<AuctionViewModel> Auctions { get; private set; }
        public AuctionService AuctionService { get; }

        public MainViewModel()
        {
            var app = Application.Current as App;
            if (app == null) return;
            AuctionService = new AuctionService(app.MainRepository, new SimpleMemberService(app.MainRepository));

            Auctions = new ObservableCollection<AuctionViewModel>(AuctionService.GetAll().Select(e => new AuctionViewModel(AuctionService, e)));
        }

        void SellExecute()
        {
            var sellView = new SellView();
            sellView.ShowDialog(); // Blocking 
            Auctions = new ObservableCollection<AuctionViewModel>(AuctionService.GetAll().Select(e => new AuctionViewModel(AuctionService, e)));
            RaisePropertyChanged("Auctions");
        }
        private bool CanSell() => true;
        public ICommand SellCommand => new RelayCommand<MainViewModel>(x => SellExecute(), x => CanSell());

    }
}
