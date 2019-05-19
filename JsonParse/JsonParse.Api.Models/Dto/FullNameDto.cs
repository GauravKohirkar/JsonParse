using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Dto
{
    public class FullNameDto
    {
        private string fullName { get; set; }
        public FullNameDto(string fullName)
        {
            this.fullName = fullName;
        }
        public string FullName => fullName;
    }
}
