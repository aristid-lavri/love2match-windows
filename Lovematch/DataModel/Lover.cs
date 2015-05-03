﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lovematch.DataModel
{
    public class Lover : INotifyPropertyChanged
    {
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(); }
        }


        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged(); }
        }


        private Gender _gender = Gender.Other;
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; OnPropertyChanged(); }
        }


        public Lover() 
        {
            FullName = String.Empty;
            BirthDate = DateTime.Now;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new
            PropertyChangedEventArgs(propertyName));
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
