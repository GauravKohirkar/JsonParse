using JsonParse.App.Repository;
using JsonParse.App.Repository.Contract;
using JsonParse.App.Service;
using JsonParse.App.Services.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace JsonParse.App
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        const int FULL_NAME_PARAM = 42, FIRST_NAME_PARAM = 23;
        static void Main(string[] args)
        {
            RegisterServices();

            DoOperation();

            DisposeServices();
            Console.ReadKey();
        }

        private static void DoOperation()
        {
            try
            {
                var jsonParseService = _serviceProvider.GetService<IJsonParseService>();
                // Item1 is the result, Item2 is the Exception message if any. Needs to be refactored to a new model.
                var filePath = jsonParseService.GetFilePath().Result;
                if (filePath.Item2 != null)
                {
                    Console.WriteLine(filePath.Item2);
                    return;
                }

                var fullName = jsonParseService.GetFullName(filePath.Item1, FULL_NAME_PARAM).Result;
                if (fullName.Item2 != null)
                {
                    Console.WriteLine(fullName.Item2);
                }
                else
                    Console.WriteLine($"The full name of user with Id {FULL_NAME_PARAM} is : {fullName.Item1.FullName}");

                var firstNames = jsonParseService.GetFirstNames(filePath.Item1, FIRST_NAME_PARAM).Result;
                if (firstNames.Item2 != null)
                {
                    Console.WriteLine(firstNames.Item2);
                }
                else
                    Console.WriteLine($"The first names of the users with age {FIRST_NAME_PARAM} is : {firstNames.Item1.FirstNames}");

                var ageFemaleMales = jsonParseService.GetAgeFemaleMale(filePath.Item1).Result;
                if (ageFemaleMales.Item2 != null)
                {
                    Console.WriteLine(ageFemaleMales.Item2);
                }
                else
                    foreach (var ageItem in ageFemaleMales.Item1)
                    {
                        Console.WriteLine($"Age : {ageItem.Age} Female : {ageItem.Female} Male : {ageItem.Male}");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IJsonParseRepository, JsonParseRepository>();
            collection.AddSingleton<IJsonParseService, JsonParseService>();
            _serviceProvider = collection.BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
