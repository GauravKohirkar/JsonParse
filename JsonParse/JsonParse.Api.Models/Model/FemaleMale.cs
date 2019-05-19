using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Model
{
    public class FemaleMale
    {
        public int Female { get; set; }
        public int Male { get; set; }
        public FemaleMale(int female, int male)
        {
            Female = female;
            Male = male;
        }
    }
}
