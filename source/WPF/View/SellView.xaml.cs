using System;
using System.IO;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using Microsoft.Win32;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window, IClosable
    {
        public SellView()
        {
            InitializeComponent();

            var app = Application.Current as App;

            var memberService = new SimpleMemberService(app.MainRepository);
            var auctionService = new AuctionService(app.MainRepository, memberService);
            this.DataContext = new SellViewModel(auctionService, memberService);
        }
    }
}
