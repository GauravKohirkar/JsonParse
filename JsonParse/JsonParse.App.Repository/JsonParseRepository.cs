using JsonParse.Api.Models.Dto;
using JsonParse.Api.Models.Errors;
using JsonParse.Api.Models.Model;
using JsonParse.App.Repository.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JsonParse.App.Repository
{
    public class JsonParseRepository : IJsonParseRepository
    {
        private const string BASE_END_POINT_KEY = "JsonParseApiEndpoint",
                             GET_FULL_NAME = "getFullName",
                             GET_FIRST_NAMES = "getFirstNames",
                             GET_AGE_FEMALE_MALE = "getAgeFemaleMale";

        private string BASE_END_POINT;

        //API Endpoint Builders
        private string JsonParseReadJsonBuilder(string baseEndpoint, string filePath) => $"{baseEndpoint}/{filePath}";
        private string JsonParseGetFullNameBuilder(string baseEndpoint, string filePath, int id) => $"{baseEndpoint}/{GET_FULL_NAME}/{id}/{filePath}";
        private string JsonParseGetFirstNameBuilder(string baseEndpoint, string filePath, int age) => $"{baseEndpoint}/{GET_FIRST_NAMES}/{age}/{filePath}";
        private string JsonParseGetAgeFemaleMaleBuilder(string baseEndpoint, string filePath) => $"{baseEndpoint}/{GET_AGE_FEMALE_MALE}/{filePath}";

        public JsonParseRepository()
        {
            BASE_END_POINT = ConfigurationManager.AppSettings[BASE_END_POINT_KEY];
        }

        public async Task<(List<User>, string)> ReadJson(string filePath)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(JsonParseReadJsonBuilder(BASE_END_POINT, filePath));
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonError = JsonConvert.DeserializeObject<ApiError>(errorResponse);
                string errorContent = jsonError != null ? jsonError.Message : "Unexpected error occurred.";
                return (null, errorContent);
            }
            string content = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<List<User>>(content), null);
        }

        public async Task<(FullNameDto, string)> GetFullName(string filePath, int id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(JsonParseGetFullNameBuilder(BASE_END_POINT, filePath, id));
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonError = JsonConvert.DeserializeObject<ApiError>(errorResponse);
                string errorContent = jsonError != null ? jsonError.Message : "Unexpected error occurred. Please check api endpoint is running.";
                return (null, errorContent);
            }
            string content = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<FullNameDto>(content), null);
        }

        public async Task<(FirstNamesDto, string)> GetFirstNames(string filePath, int age)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(JsonParseGetFirstNameBuilder(BASE_END_POINT, filePath, age));
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonError = JsonConvert.DeserializeObject<ApiError>(errorResponse);
                string errorContent = jsonError != null ? jsonError.Message : "Unexpected error occurred. Please check api endpoint is running.";
                return (null, errorContent);
            }
            string content = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<FirstNamesDto>(content), null);
        }

        public async Task<(List<AgeFemaleMaleDto>, string)> GetAgeFemaleMale(string filePath)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(JsonParseGetAgeFemaleMaleBuilder(BASE_END_POINT, filePath));
            if (response == null || response.StatusCode != HttpStatusCode.OK)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var jsonError = JsonConvert.DeserializeObject<ApiError>(errorResponse);
                string errorContent = jsonError != null ? jsonError.Message : "Unexpected error occurred. Please check api endpoint is running.";
                return (null, errorContent);
            }
            string content = await response.Content.ReadAsStringAsync();
            return (JsonConvert.DeserializeObject<List<AgeFemaleMaleDto>>(content), null);
        }
    }
}
