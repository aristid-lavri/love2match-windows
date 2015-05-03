using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lovematch.DataModel;
using System.Collections.ObjectModel;

namespace Lovematch.ViewModels
{
    class ResultViewModel
    {

        private  ObservableCollection<Lover> _couple = new ObservableCollection<Lover>(
            new Lover[] { new Lover(), new Lover() });
        public  ObservableCollection<Lover> Couple
        {
            get { return _couple; }
            set { _couple = value; }
        }


        public int ShakeBonus { get; set; }

        public int LoveScore { get; set; }

        public bool IsSpecialScore { get; set; }


        public ResultViewModel() { }


        public ResultViewModel(ObservableCollection<Lover> couple) 
        {
            Couple = couple;
        }



        public void CalculateLoveScore() 
        {
            if (IsSpecialCase())
                LoveScore = GetSpecialScore();
            else
                LoveScore = GetNormalScore();
        }


        private int GetNormalScore() 
        {
            int score = 0;
            // TODO Love algorithm

            score = Couple[0].FullName.Length +  Couple[1].FullName.Length;
            score = (score > 100) ? 100 : score;

            return score;
        }



        private int GetSpecialScore() 
        {
            int score = 110;
            return score; 
        }


        private bool IsSpecialCase() 
        {
            bool isSpecial = false;

            // TODO

            return isSpecial;
        }



    }
}
