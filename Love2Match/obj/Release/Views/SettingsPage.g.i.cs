﻿#pragma checksum "E:\users\godidier\Works\me\devel\love2match\Love2Match\Love2Match\Views\SettingsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A33DF77BD91FE320686A0892B1A9F571"
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


namespace Love2Match.Views {
    
    
    public partial class SettingsPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel ContentPanel;
        
        internal Microsoft.Phone.Controls.ListPicker ConvertionPicker;
        
        internal Microsoft.Phone.Controls.ListPicker LanguagePicker;
        
        internal Microsoft.Phone.Controls.ToggleSwitch NumberToggle;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Love2Match;component/Views/SettingsPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.StackPanel)(this.FindName("ContentPanel")));
            this.ConvertionPicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("ConvertionPicker")));
            this.LanguagePicker = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("LanguagePicker")));
            this.NumberToggle = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("NumberToggle")));
        }
    }
}

