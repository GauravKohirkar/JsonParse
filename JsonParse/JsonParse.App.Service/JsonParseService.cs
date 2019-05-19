using JsonParse.Api.Models.Dto;
using JsonParse.Api.Models.Model;
using JsonParse.App.Repository.Contract;
using JsonParse.App.Services.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace JsonParse.App.Service
{
    public class JsonParseService : IJsonParseService
    {
        const string ENVIRONMENT_PATH_KEY = "EnvironmentPath", FILE_NAME_KEY = "FileName";
        private readonly IJsonParseRepository _jsonParseRepository;
        public JsonParseService(IJsonParseRepository jsonParseRepository)
        {
            _jsonParseRepository = jsonParseRepository;
        }

        public async Task<(List<User>, string)> ReadJson(string filePath)
        {
            return await _jsonParseRepository.ReadJson(filePath);
        }

        public async Task<(FullNameDto, string)> GetFullName(string filePath, int id)
        {
            return await _jsonParseRepository.GetFullName(filePath, id);
        }
        
        public async Task<(FirstNamesDto, string)> GetFirstNames(string filePath, int age)
        {
            return await _jsonParseRepository.GetFirstNames(filePath, age);
        }

        public async Task<(List<AgeFemaleMaleDto>, string)> GetAgeFemaleMale(string filePath)
        {
            return await _jsonParseRepository.GetAgeFemaleMale(filePath);
        }

        public async Task<(string, string)> GetFilePath()
        {
            try
            {
                var taskEnvironmentPath = Task.Factory.StartNew(() => ConfigurationManager.AppSettings[ENVIRONMENT_PATH_KEY]);
                var environmentPath = await taskEnvironmentPath;

                if (String.IsNullOrWhiteSpace(environmentPath))
                {
                    environmentPath = AppDomain.CurrentDomain.BaseDirectory;
                }

                var taskFileName = Task.Factory.StartNew(() => ConfigurationManager.AppSettings[FILE_NAME_KEY]);
                var fileName = await taskFileName;
                return ((environmentPath + "\\" + fileName), null);
            }
            catch(Exception ex)
            {
                return (null, $"Exception occurred while getting the file path: {ex.Message}");
            }
        }
    }
}
