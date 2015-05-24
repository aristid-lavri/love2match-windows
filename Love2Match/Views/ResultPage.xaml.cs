using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Love2Match.ViewModels;
//using System.Threading;
using System.Windows.Threading;

namespace Love2Match.Views
{
    public partial class ResultPage : PhoneApplicationPage
    {

        private ResultViewModel vm = new ResultViewModel();
        private DispatcherTimer ScoreAnimationTimer = new DispatcherTimer();

        private double DisplayedScore;
        private double HeartMaskInitHeight;

        public ResultPage()
        {
            InitializeComponent();
            DataContext = vm;

            HeartMaskInitHeight = HeartMaskShape.Height;

            ScoreAnimationTimer.Interval = TimeSpan.FromMilliseconds(5);
            ScoreAnimationTimer.Tick += AnimateScore;
            
            Loaded += (s, e) => 
            {
                ScoreAnimationTimer.Start();
            };
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("action")) 
            {
                if (NavigationContext.QueryString["action"] == "calculate") 
                {
                    ShakePanel.Visibility = Visibility.Visible;
                    ScorePanel.Visibility = Visibility.Collapsed;
                    WaitShakeBonus();

                    Lover1Text.Text = MainViewModel.Couple[0].FullName;
                    Lover2Text.Text = MainViewModel.Couple[1].FullName;
                    WaitShakeBonus();

                    vm = new ResultViewModel(MainViewModel.Couple);
                    vm.CalculateLoveScore();

                    ShakePanel.Visibility = Visibility.Collapsed;
                    ScorePanel.Visibility = Visibility.Visible;
                    
                }
            }
        }

        
        
        

        private  void WaitShakeBonus() 
        {
            //ShakeGrid.Visibility = Visibility.Visible;
            //Thread.Sleep(3000);
            
            //ShakeGrid.Visibility = Visibility.Collapsed;
        }
       


        void AnimateScore(object sender, EventArgs e)
        {
            if (DisplayedScore >= vm.LoveScore) // The score is calculated in OnNavigatedTo
            {
                ScoreAnimationTimer.Stop();
            }
            else 
            {
                HeartMaskShape.Height -= (HeartMaskInitHeight / 100); // remove one unit of the percentage of initial height
                DisplayedScore++;
                ScoreTextBlock.Text = DisplayedScore + "%";
            }
#if(DEBUG) 
            System.Diagnostics.Debug.WriteLine("LoveScore='"+vm.LoveScore+"', "
                +"Displayed Score='"+DisplayedScore+"', "
                +"MaskHeight='"+HeartMaskShape.Height+"'");

#endif
        }

       

        private void AppBarSave_Click(object sender, EventArgs e)
        {
            // TODO Save the match 
            NavigationService.Navigate(new Uri("/Views/MatchesPage.xaml", UriKind.Relative));
        }
    }
}