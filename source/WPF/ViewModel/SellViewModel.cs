using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using Microsoft.Win32;
using WPF.Command;

namespace WPF.ViewModel
{
    public class SellViewModel : ViewModelBase
    {
        public IAuctionService AuctionService { get; }
        public IMemberService MemberService { get; }
        public Auction Auction { get; set; } = new Auction();
        public string ImagePath { get; set; } = "";

        public SellViewModel(IAuctionService auctionService, IMemberService memberService)
        {
            AuctionService = auctionService;
            MemberService = memberService;

            Auction.StartDateTimeUtc = DateTime.UtcNow;
            Auction.EndDateTimeUtc = DateTime.UtcNow.AddDays(1);
        }
        void AddImageExecute()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
                Auction.Image = File.ReadAllBytes(ImagePath);
            }
        }
        private bool CanAddImage() => true;
        public ICommand AddImageCommand => new RelayCommand<SellViewModel>(x => AddImageExecute(), x => CanAddImage());


        void SaveExecute()
        {
            Auction.Seller = MemberService.GetCurrentMember();
            Auction.IsClosed = false;
            Auction.IsRunning = true;
            if (Auction.StartDateTimeUtc < DateTime.UtcNow)
            {
                Auction.StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10);
            }
            AuctionService.Save(Auction);
            //Close();
        }
        private bool CanSave() => true;
        public ICommand SaveCommand => new RelayCommand<SellViewModel>(x => SaveExecute(), x=> CanSave());
    }
}
