using JsonParse.Api.Models.Dto;
using JsonParse.Api.Models.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonParse.App.Repository.Contract
{
    public interface IJsonParseRepository
    {
        Task<(List<User>, string)> ReadJson(string filePath);
        Task<(FullNameDto, string)> GetFullName(string filePath, int id);
        Task<(FirstNamesDto, string)> GetFirstNames(string filePath, int id);
        Task<(List<AgeFemaleMaleDto>, string)> GetAgeFemaleMale(string filePath);
    }
}
