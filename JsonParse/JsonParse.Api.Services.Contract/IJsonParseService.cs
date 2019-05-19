using JsonParse.Api.Models.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonParse.Api.Services.Contract
{
    public interface IJsonParseService
    {
        Task<List<User>> ReadJson(string filePath);
        Task<string> GetFullName(string filePath, int id);
        Task<string> GetFirstNames(string filePath, int age);
        Task<List<AgeFemaleMale>> GetAgeFemaleMale(string filePath);
    }
}
