using JsonParse.Api.Models.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonParse.Api.Repository.Contract
{
    public interface IJsonParseRepository
    {
        Task<List<User>> ReadJson(string filePath);
        Task<string> GetFullName(string filePath, int id);
        Task<List<User>> GetFirstNames(string filePath, int age);
        Task<List<AgeFemaleMale>> GetAgeFemaleMale(string filePath);
    }
}
