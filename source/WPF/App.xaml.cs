using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.Entity;
using DotNetBay.Data.Provider.FileStorage;
using DotNetBay.Interfaces;
using System.Threading;
using System.Globalization;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string Reponame = "mainRepo";
        public readonly IMainRepository MainRepository = new FileSystemMainRepository(Reponame);

        public IAuctionRunner AuctionRunner { get; private set; }

        public App()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.AuctionRunner = new AuctionRunner(this.MainRepository);
            this.AuctionRunner.Start();

            var memberService = new SimpleMemberService(this.MainRepository);
            var service = new AuctionService(this.MainRepository, memberService);

            if (!service.GetAll().Any())
            {
                var me = memberService.GetCurrentMember();

                service.Save(new Auction
                {
                    Title = "My First Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });
            }
        }
        
    }
}
