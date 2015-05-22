using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Love2Match.DataModel;
using System.Collections.ObjectModel;

namespace Love2Match.ViewModels
{
    public class ResultViewModel
    {

        public static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private ObservableCollection<Lover> _couple = new ObservableCollection<Lover>(
            new Lover[] { new Lover(), new Lover() });
        public ObservableCollection<Lover> Couple
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
            int bonus = 0;
            Lover lover1 = Couple[0];
            Lover lover2 = Couple[1];

            // Expression Number
            int lover1XpNumber = ExpressionNumber(lover1.FullName);
            int lover2XpNumber = ExpressionNumber(lover2.FullName);
            if (lover1XpNumber == lover2XpNumber)
            {
                score = 100;
            }
            else
            {
                // TODO find a more formal way to combine the numbers
                //score = ((lover1XpNumber + lover2XpNumber) % 9) * 10; 
                score = CoreNumberDigitsSum(lover1XpNumber + lover2XpNumber) * 10; 
                score = (score > 100) ? 98 : score;
            }

            // Birthdate calculation
            if ((lover1.BirthDate.HasValue) && (lover2.BirthDate.HasValue))
            {
                int lifePathScore = 0;
                int lifePath1 = LifePathnumber(lover1.BirthDate.Value);
                int lifePath2 = LifePathnumber(lover2.BirthDate.Value);

                if (lifePath1 == lifePath2)
                {
                    lifePathScore = 100;
                }
                else
                {
                    lifePathScore = CoreNumberDigitsSum(lifePath1 + lifePath2) * 10;
                    lifePathScore = (lifePathScore > 100) ? 98 : lifePathScore;
                }

                score = (score + lifePathScore) / 2;
                bonus++;// Birthdate Info bonus
            }

            // Gender Calculation
            if ((lover1.Gender != Gender.Undefined) && (lover2.Gender != Gender.Undefined))
            {
                if (lover1.Gender == lover2.Gender)
                {
                    if (score < 50)
                        score -= 10;
                }
                else
                {
                    if (((lover1.Gender == Gender.Male) && (lover2.Gender == Gender.Female)) ||
                        ((lover1.Gender == Gender.Female) && (lover2.Gender == Gender.Male)))
                        score += 10;
                }

                bonus++;// Gender Info bonus
            }

            int finalScore = score + bonus;
            return ((finalScore > 100) ? 100 : finalScore);
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


        /// <summary>
        /// http://themeaningofthename.com/numerology-calculator/
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int PythagoreanSystemIndexOf(char c)
        {
            int index = Alphabet.IndexOf(c, 0) + 1;
            return (index > 9) ? index % 9 : index;
        }




        public static bool CoreNumber(int number) 
        {
            return ((number == 22) || (number == 11) || (number < 10)) ;
        }


        public static int CoreNumberDigitsSum(int number)
        {
            int n = number;
            n = Math.Abs(n);
            if (!CoreNumber(n))
            {
                int order = 1;
                while ((order * 10) < number)
                    order *= 10;

                int d = number / order; // Integer division
                n = d + CoreNumberDigitsSum(n % order);
            }
            //if (!CoreNumber(n)) // If the previous (recursive) digits sum is not a core number
            //    CoreNumberDigitsSum(n);
            return n;
        }


        public static int ExpressionNumber(string name)
        {
            int n = 0;
            name = name.ToUpper();
            foreach (char c in name)
                n += PythagoreanSystemIndexOf(c);

            return CoreNumberDigitsSum(n);
        }


        public static int LifePathnumber(DateTime date) 
        {
            int number = (int) (date.Year * Math.Pow(10, 4) + date.Month * Math.Pow(10,2) + date.Day);

            return CoreNumberDigitsSum(number); 
        }

    }
}
