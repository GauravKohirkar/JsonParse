using JsonParse.Api.Repository;
using JsonParse.Api.Services;
using System;
using System.Linq;
using Xunit;

namespace JsonParse.Api.Tests
{
    public class ApiTests
    {
        [Fact]
        public async void GetFullNameTest1()
        {
            JsonParseRepository objRepo = new JsonParseRepository();
            JsonParseService objService = new JsonParseService(objRepo);
            var fullName = await objService.GetFullName("D:\\Seven West Git\\Core\\example_data.json", 41);
            Assert.Equal("Frank Zappa", fullName);
        }
        [Fact]
        public async void GetFullNameTest2()
        {
            JsonParseRepository objRepo = new JsonParseRepository();
            JsonParseService objService = new JsonParseService(objRepo);
            var fullName = await objService.GetFullName("D:\\Seven West Git\\Core\\example_data.json", 31);
            Assert.Equal("Jill Scott", fullName);
        }
        [Fact]
        public async void GetFirstNamesTest()
        {
            JsonParseRepository objRepo = new JsonParseRepository();
            JsonParseService objService = new JsonParseService(objRepo);
            var fullName = await objService.GetFirstNames("D:\\Seven West Git\\Core\\example_data.json", 66);
            Assert.Equal("Jill,Anna,Janet", fullName);
        }
        [Fact]
        public async void GetAgeFemaleMaleTest()
        {
            JsonParseRepository objRepo = new JsonParseRepository();
            JsonParseService objService = new JsonParseService(objRepo);
            var ageFemaleMales = await objService.GetAgeFemaleMale("D:\\Seven West Git\\Core\\example_data.json");
            var age = ageFemaleMales.Where(x => x.Age == 66).FirstOrDefault().Female;
            Assert.Equal(1, age);
        }
    }
}
