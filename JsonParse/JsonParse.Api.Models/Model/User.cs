using System;
using System.Collections.Generic;
using System.Text;

namespace JsonParse.Api.Models.Model
{
    public class User
    {
        public int id { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public int? age { get; set; }
        public string gender { get; set; }
    }
}
