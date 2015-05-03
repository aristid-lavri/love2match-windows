using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Lovematch.Resources;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;

using Lovematch.Utils;
using Lovematch.DataModel;
using Lovematch.ViewModels;

namespace Lovematch.Views
{
    public partial class MainPage : PhoneApplicationPage
    {

        MainViewModel vm = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = vm;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // TODO bind
            Lover1TexBox.Text = MainViewModel.Couple[0].FullName;
            Lover2TexBox.Text = MainViewModel.Couple[1].FullName;
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            // TODO bind
            MainViewModel.Couple[0].FullName = Lover1TexBox.Text;
            MainViewModel.Couple[1].FullName = Lover2TexBox.Text;
            base.OnNavigatedFrom(e);
        }

       

        private void AppBarSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/SettingsPage.xaml", UriKind.Relative));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/AboutPage.xaml", UriKind.Relative));
        }

        private void AppBarClear_Click(object sender, EventArgs e)
        {
            vm = new MainViewModel();
        }

        private void AppBarMatch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Lover1TexBox.Text) || String.IsNullOrWhiteSpace(Lover2TexBox.Text))
                MessageBox.Show("Please, enter informations for the two lovers");
            else
                NavigationService.Navigate(new Uri("/Views/ResultPage.xaml?action=calculate", UriKind.Relative));

        }


        private void Lover1TexBox_ActionIconTapped(object sender, EventArgs e)
        {
            // TODO send with parameter
            NavigationService.Navigate(new Uri("/Views/LoverPage.xaml?loverIndex=0", UriKind.Relative));
        }


        private void Lover2TexBox_ActionIconTapped(object sender, EventArgs e)
        {
            // TODO send with parameter
            NavigationService.Navigate(new Uri("/Views/LoverPage.xaml?loverIndex=1", UriKind.Relative));
        }

        







        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}



    }
}