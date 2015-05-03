using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Lovematch.Views
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void AppBarSave_Click(object sender, EventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("search_langage"))
                settings.Remove("search_langage");
            settings.Add("search_langage", "en");

            if (settings.Contains("convertion_mode"))
                settings.Remove("convertion_mode");
            settings.Add("convertion_mode", "NumberToStrings");

            settings.Save();
            NavigationService.GoBack();  
        }

        private void AppBarCancel_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();            
        }
    }
}