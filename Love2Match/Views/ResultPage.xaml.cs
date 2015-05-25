using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.Devices.Notification;
using ShakeGestures;

using Love2Match.ViewModels;
//using System.Threading;
using System.Windows.Threading;

namespace Love2Match.Views
{
    public partial class ResultPage : PhoneApplicationPage
    {

        private ResultViewModel vm = new ResultViewModel();
        private DispatcherTimer ScoreAnimationTimer = new DispatcherTimer();
        private DispatcherTimer ShakeTimer = new DispatcherTimer();
        private VibrationDevice VibrationDev = VibrationDevice.GetDefault();

        private double DisplayedScore;
        private double HeartMaskInitHeight;
        private byte ShakeBonus = 0;
        private const byte SHAKE_BONUS_COEF = 3; // A multiplier for shakebonus
        private const byte SHAKE_BONUS_MAX = 10;
        private TimeSpan ShakeTime = TimeSpan.FromSeconds(2);


        public ResultPage()
        {
            InitializeComponent();
            Loaded += ResultPage_Loaded;
            DataContext = vm;

            HeartMaskInitHeight = HeartMaskShape.Height;
            ShakeBar.Minimum *= SHAKE_BONUS_COEF;
            ShakeBar.Maximum *= SHAKE_BONUS_COEF;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("action"))
            {
                if (NavigationContext.QueryString["action"] == "calculate")
                {
                    
                    Lover1Text.Text = MainViewModel.Couple[0].FullName;
                    Lover2Text.Text = MainViewModel.Couple[1].FullName;

                    vm = new ResultViewModel(MainViewModel.Couple);
                    vm.CalculateLoveScore();
                }
            }
        }



        private void ShakeDetected(object sender, ShakeGestureEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                if (ShakeBonus < SHAKE_BONUS_MAX * SHAKE_BONUS_COEF) 
                {
                    ShakeBonus++;
                    var bonus = ((double)ShakeBonus / (double)SHAKE_BONUS_COEF);
                    ShakeBonusTextBox.Text = String.Format("+{0}",  Math.Round(bonus, 1));
                    ShakeBar.Value = ShakeBonus;
                    //VibrationDev.Vibrate(TimeSpan.FromSeconds(0.5));
                }
            });
        }


        /// <summary>
        /// Check if ShakeTime span has ended and show the score if so
        /// Deactivate the ShakeGestureHelper and ShowScore()
        /// else decrease the ShakeTime TimeSpan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShakeTimer_Tick(object sender, EventArgs e)
        {
            if (ShakeTime.Seconds <= 0) 
            {
                ShakeTimer.Stop();
                ShakeGesturesHelper.Instance.Active = false;
                ShowScore();
            }
            else 
            {
                ShakeTime = TimeSpan.FromSeconds(ShakeTime.Seconds - 1);
                ShakeTimeTextBox.Text = ShakeTime.Seconds.ToString();
            }
        }


        private void ShowScore()
        {
            ShakePanel.Visibility = Visibility.Collapsed;
            ScorePanel.Visibility = Visibility.Visible;

            ScoreAnimationTimer.Interval = TimeSpan.FromMilliseconds(5);
            ScoreAnimationTimer.Tick += AnimateScore;
            ScoreAnimationTimer.Start();
        }



        private void WaitShakeBonus() 
        {
            ShakePanel.Visibility = Visibility.Visible;
            ScorePanel.Visibility = Visibility.Collapsed;

            ShakeGesturesHelper.Instance.ShakeGesture += new EventHandler<ShakeGestureEventArgs>(ShakeDetected);
            ShakeGesturesHelper.Instance.MinimumRequiredMovesForShake = 2;
            ShakeGesturesHelper.Instance.Active = true;

            // Shake Controls Initializations
            ShakeTimeTextBox.Text = String.Format("{0}", ShakeTime.Seconds + 1);
            ShakeBonusTextBox.Text = "+0";
            ShakeBar.Value = ShakeBonus;

            ShakeTimer.Interval = TimeSpan.FromSeconds(3);
            ShakeTimer.Tick += ShakeTimer_Tick;
            ShakeTimer.Start();
        }



        private void AnimateScore(object sender, EventArgs e)
        {
            if (DisplayedScore >= vm.LoveScore) // The score is calculated in OnNavigatedTo
            {
                ScoreAnimationTimer.Stop();
                if (vm.LoveScore == 100)
                {
                    VibrationDev.Vibrate(TimeSpan.FromSeconds(1));
                }
            }
            else
            {
                HeartMaskShape.Height -= (HeartMaskInitHeight / 100); // remove one unit of the percentage of initial height
                DisplayedScore++;
                ScoreTextBlock.Text = DisplayedScore + "%";
            }
#if(DEBUG)
            System.Diagnostics.Debug.WriteLine("LoveScore='" + vm.LoveScore + "', "
                + "Displayed Score='" + DisplayedScore + "', "
                + "MaskHeight='" + HeartMaskShape.Height + "'");

#endif
        }


        void ResultPage_Loaded(object sender, RoutedEventArgs e)
        {
            WaitShakeBonus();
        }



        private void AppBarSave_Click(object sender, EventArgs e)
        {
            // TODO Save the match 
            NavigationService.Navigate(new Uri("/Views/MatchesPage.xaml", UriKind.Relative));
        }
    }
}