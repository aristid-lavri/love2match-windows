using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lovematch.DataModel;
using System.Collections.ObjectModel;

namespace Lovematch.ViewModels
{
    public class MainViewModel
    {
        private static ObservableCollection<Lover> _couple = new ObservableCollection<Lover>(
            new Lover[] {new Lover(), new Lover() });
        public static ObservableCollection<Lover> Couple 
        {
            get { return _couple; }
            set { _couple = value; }
        }


    }
}
