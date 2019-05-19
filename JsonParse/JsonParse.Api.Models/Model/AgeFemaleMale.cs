using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Model
{
    public class AgeFemaleMale
    {
        public int Age { get; }
        public int Female { get; }
        public int Male { get; }
        public AgeFemaleMale(int age, int female, int male)
        {
            Age = age;
            Female = female;
            Male = male;
        }
    }
}
