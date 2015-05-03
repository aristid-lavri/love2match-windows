using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Lovematch.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace Lovematch.Views
{
    public partial class ResultPage : PhoneApplicationPage
    {

        ResultViewModel vm = new ResultViewModel();

        public ResultPage()
        {
            InitializeComponent();
            DataContext = vm;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // TODO if from MainViewModel
            ShakePanel.Visibility = Visibility.Visible;
            ScorePanel.Visibility = Visibility.Collapsed;

            Lover1Text.Text = MainViewModel.Couple[0].FullName;
            Lover2Text.Text = MainViewModel.Couple[1].FullName;
            WaitShakeBonus();

            vm = new ResultViewModel(MainViewModel.Couple);
            vm.CalculateLoveScore();


            ShakePanel.Visibility = Visibility.Collapsed;
            ScorePanel.Visibility = Visibility.Visible;
            ShowLoveScore();

        }

        
        
        

        private  void WaitShakeBonus() 
        {
            //ShakeGrid.Visibility = Visibility.Visible;
            //Thread.Sleep(3000);
            
            //ShakeGrid.Visibility = Visibility.Collapsed;
        }
        


        private void ShowLoveScore()
        {
            // TODO animate score display
            ScoreTextBlock.Text = vm.LoveScore.ToString() + "%";
            HeartMaskShape.Height = 300;
            double height = HeartMaskShape.Height;
            height = height - vm.LoveScore * (height / 100);
            HeartMaskShape.Height = height;

        }

        private void AppBarSave_Click(object sender, EventArgs e)
        {
            // TODO Save the match 
            NavigationService.Navigate(new Uri("/Views/MatchesPage.xaml", UriKind.Relative));
        }
    }
}