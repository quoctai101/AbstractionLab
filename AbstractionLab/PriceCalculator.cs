using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLab
{
    class PriceCalculator
    {
        private float priceperday;
        private int numberofday;
        private string season;
        private string discount;

        public float Priceperday
        {
            get { return priceperday; }
            set { if (value < 0) priceperday = 0; else priceperday = value; }
        }
        public int Numberofday
        {
            get { return numberofday; }
            set { if (value < 0) numberofday = 0; else numberofday = value; }
        }
        public string Season
        {
            get { return season; }
            set { season = value; }
        }
        public string Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public PriceCalculator(float Priceperday, int Numberofday, string Season)
        {
            this.Priceperday = Priceperday;
            this.Numberofday = Numberofday;
            this.Season = Season;
            this.Discount = "None";
        }
        public PriceCalculator(float Priceperday, int Numberofday, string Season, string Discount)
            : this(Priceperday, Numberofday, Season)
        {
            this.Discount = Discount;
        }
        public float calc()
        {
            float percentDis = 0;
            int multiSeason = 1;
            switch (discount)
            {
                case "VIP":
                    percentDis = 0.2f;
                    break;
                case "SecondVisit":
                    percentDis = 0.1f;
                    break;
                default:
                    break;
            }
            switch (season)
            {
                case "Spring":
                    multiSeason = 2;
                    break;
                case "Winter":
                    multiSeason = 3;
                    break;
                case "Summer":
                    multiSeason = 4;
                    break;
                default:
                    break;
            }
            return priceperday * numberofday * multiSeason * (1 - percentDis);
        }
    }
}
