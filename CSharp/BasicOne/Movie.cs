using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOne
{
    class Movie
    {
        public string name;
        private string rating;
        public static int movieCount;
        public Movie(string title, string rateus)
        {
            this.name = title;
            this.Rating = rateus;
            movieCount++;
        }
        public string Rating
        {
            get { return rating; }
            set {
            if(value == "G"|| value == "PG")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }
    }
}
