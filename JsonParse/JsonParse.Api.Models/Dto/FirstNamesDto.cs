using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Dto
{
    public class FirstNamesDto
    {
        private string firstNames { get; set; }
        public FirstNamesDto(string firstNames)
        {
            this.firstNames = firstNames;
        }
        public string FirstNames => firstNames;
    }
}
