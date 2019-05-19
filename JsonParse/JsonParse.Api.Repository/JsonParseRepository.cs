using JsonParse.Api.Models.Model;
using JsonParse.Api.Repository.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace JsonParse.Api.Repository
{
    public class JsonParseRepository : IJsonParseRepository
    {
        public async Task<List<User>> ReadJson(string filePath)
        {
            List<User> users;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return users;
        }
        public async Task<string> GetFullName(string filePath, int id)
        {
            var users = await ReadJson(filePath);
            if (users == null)
                return null;

            var fullName = users.FirstOrDefault(x => x.id == id);
            if (fullName != null)
                return fullName.first + " " + fullName.last;
            return null;
        }
        public async Task<List<User>> GetFirstNames(string filePath, int age)
        {
            var users = await ReadJson(filePath);
            if (users == null)
                return null;

            var ageUsers = users.Where(x => x.age == age).ToList();
            if (ageUsers != null)
            {
                return ageUsers;
            }
            return null;
        }

        // Here we are assuming only M and F are the genders.
        public async Task<List<AgeFemaleMale>> GetAgeFemaleMale(string filePath)
        {
            var users = await ReadJson(filePath);
            if (users == null)
                return null;

            List<AgeFemaleMale> ageFemaleMales = new List<AgeFemaleMale>();
            Dictionary<int, FemaleMale> dictAgeFemaleMale = new Dictionary<int, FemaleMale>();

            var ageSortedUsers = users.OrderBy(x => x.age).ToList();
            foreach (var user in ageSortedUsers)
            {
                if (user.gender == "M")
                {
                    if (dictAgeFemaleMale.ContainsKey(user.age.Value))
                        dictAgeFemaleMale[user.age.Value].Male++;
                    else
                        dictAgeFemaleMale.Add(user.age.Value, new FemaleMale(0, 1));
                }

                else if (user.gender == "F")
                {
                    if (dictAgeFemaleMale.ContainsKey(user.age.Value))
                        dictAgeFemaleMale[user.age.Value].Female++;
                    else
                        dictAgeFemaleMale.Add(user.age.Value, new FemaleMale(1, 0));
                }
                else
                {
                    if (!dictAgeFemaleMale.ContainsKey(user.age.Value))
                        dictAgeFemaleMale.Add(user.age.Value, new FemaleMale(0, 0));
                }
            }
            foreach (var item in dictAgeFemaleMale)
            {
                ageFemaleMales.Add(new AgeFemaleMale(item.Key, item.Value.Female, item.Value.Male));
            }
            return ageFemaleMales;
        }
    }
}
