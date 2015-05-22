using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Love2Match.Views
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();

            

            Assembly asm = Assembly.GetExecutingAssembly();
            _appTitle = ((AssemblyTitleAttribute)Attribute
                .GetCustomAttribute(asm, typeof(AssemblyTitleAttribute))).Title;
            
            _appVersion = ((AssemblyFileVersionAttribute)Attribute
                .GetCustomAttribute(asm, typeof(AssemblyFileVersionAttribute))).Version; // TODO take verion

            DataContext = this.DataContext;
        }

        // TODO Bind the properties

        private string _appTitle;
        public string AppTitle 
        {
            get { return _appTitle; }
        }



        private string _appVersion;
        public string AppVersion
        {
            get { return _appVersion; }
        }


        private string _appAuthor = "Didier G. <godidier@godidier.com>";
        public string AppAuthor
        {
            get { return _appAuthor; }
        }


        private string _appLicense = "BSD";
        public string AppLicense
        {
            get { return _appLicense; }
        }



        private void RateButton_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask rev = new MarketplaceReviewTask();
            rev.Show();
        }

    }
}