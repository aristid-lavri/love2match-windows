using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Love2Match.DataModel;
using Love2Match.ViewModels;
using System.Collections.ObjectModel;

namespace Love2Match.Views
{
    public partial class LoverPage : PhoneApplicationPage
    {
        private ObservableCollection<Lover> _loverCollection = new ObservableCollection<Lover>(
            new Lover[] {new Lover()});

        public LoverPage()
        {
            InitializeComponent();
            DataContext = _loverCollection[0];
        }

        private void AppBarCheck_Click(object sender, EventArgs e)
        {
            // TODO if from MainViewmodel
            Lover lover = _loverCollection[0];
            lover.FullName = FullNameTextBox.Text;
            lover.BirthDate = BirthDatePicker.Value.GetValueOrDefault();
            if (MaleButton.IsChecked.GetValueOrDefault(false))
                lover.Gender = Gender.Male;
            if (FemaleButton.IsChecked.GetValueOrDefault(false))
                lover.Gender = Gender.Female;

            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.Back)
                return;

            if (NavigationContext.QueryString.ContainsKey("loverIndex"))
            {
                // TODO if from MainViewmodel
                int loverIndex = int.Parse(NavigationContext.QueryString["loverIndex"]);
                if ((loverIndex == 0) || (loverIndex == 1))
                {
                    _loverCollection[0] = MainViewModel.Couple[loverIndex];
                    Lover lover = _loverCollection[0];
                    FullNameTextBox.Text = lover.FullName;
                    BirthDatePicker.Value = lover.BirthDate;
                    if (lover.Gender == Gender.Male)
                        MaleButton.IsChecked = true;
                    if (lover.Gender == Gender.Female)
                        FemaleButton.IsChecked = true;
                }
            }
            
        }

    }
}