using JsonParse.Api.Models.Model;
using JsonParse.Api.Repository.Contract;
using JsonParse.Api.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonParse.Api.Services
{
    public class JsonParseService : IJsonParseService
    {
        private readonly IJsonParseRepository _jsonParseRepository;
        public JsonParseService(IJsonParseRepository jsonParseRepository)
        {
            _jsonParseRepository = jsonParseRepository;
        }
        public async Task<List<User>> ReadJson(string filePath)
        {
            return await _jsonParseRepository.ReadJson(filePath);
        }

        public async Task<string> GetFullName(string filePath, int id)
        {
            return await _jsonParseRepository.GetFullName(filePath, id);
        }

        public async Task<string> GetFirstNames(string filePath, int age)
        {
            var ageUsers = await _jsonParseRepository.GetFirstNames(filePath, age);
            if(ageUsers != null)
            {
                return string.Join(",", ageUsers.Select(x => x.first));
            }
            return null;
        }

        public async Task<List<AgeFemaleMale>> GetAgeFemaleMale(string filePath)
        {
            return await _jsonParseRepository.GetAgeFemaleMale(filePath);
        }
    }
}
