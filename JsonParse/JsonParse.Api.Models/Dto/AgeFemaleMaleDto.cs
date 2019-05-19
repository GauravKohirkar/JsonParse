using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Dto
{
    public class AgeFemaleMaleDto
    {
        private int age { get; }
        private int female { get; }
        private int male { get; }
        public AgeFemaleMaleDto(int age, int female, int male)
        {
            this.age = age;
            this.female = female;
            this.male = male;
        }
        public int Age => age;
        public int Female => female;
        public int Male => male;
    }
}
