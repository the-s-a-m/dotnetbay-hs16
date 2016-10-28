using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using WPF.ViewModel;
using BidView = WPF.View.BidView;
using SellView = WPF.View.SellView;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
