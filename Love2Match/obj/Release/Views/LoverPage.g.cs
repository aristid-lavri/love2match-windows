﻿#pragma checksum "C:\Users\DGOHOUROU\Works\lovematch\Lovematch\Lovematch\Views\LoverPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "275225EC4A04DEA92A7D3A2444D03C06"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Lovematch.Views {
    
    
    public partial class LoverPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox FullNameTextBox;
        
        internal Microsoft.Phone.Controls.DatePicker BirthDatePicker;
        
        internal System.Windows.Controls.RadioButton MaleButton;
        
        internal System.Windows.Controls.RadioButton FemaleButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Lovematch;component/Views/LoverPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.FullNameTextBox = ((System.Windows.Controls.TextBox)(this.FindName("FullNameTextBox")));
            this.BirthDatePicker = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("BirthDatePicker")));
            this.MaleButton = ((System.Windows.Controls.RadioButton)(this.FindName("MaleButton")));
            this.FemaleButton = ((System.Windows.Controls.RadioButton)(this.FindName("FemaleButton")));
        }
    }
}

