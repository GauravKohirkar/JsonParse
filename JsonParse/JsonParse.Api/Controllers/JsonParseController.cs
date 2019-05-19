using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JsonParse.Api.Models.Dto;
using JsonParse.Api.Models.Errors;
using JsonParse.Api.Models.Model;
using JsonParse.Api.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JsonParse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonParseController : ControllerBase
    {
        private readonly IJsonParseService _jsonParseService;
        public JsonParseController(IJsonParseService jsonParseService)
        {
            _jsonParseService = jsonParseService;
        }

        [HttpGet("{*filePath}")]
        public async Task<ActionResult<string>> GetJson(string filePath)
        {
            try
            {
                if (filePath == null)
                    return null;

                var list = await _jsonParseService.ReadJson(filePath);
                return Ok(list);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(new NotFoundError("The json was not found"));
            }
            catch (JsonReaderException ex)
            {
                return BadRequest(new InternalServerError("json file is not valid"));
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS
                return BadRequest(new InternalServerError(ex.Message));
            }
        }

        [Route("getFullName/{id}/{*filePath}")]
        [HttpGet]
        public async Task<ActionResult<string>> GetFullName(string filePath, int id)
        {
            try
            {
                var fullName = await _jsonParseService.GetFullName(filePath, id);
                if (fullName == null)
                    return NotFound(new NotFoundError($"Full names with id {id} not found!"));

                // Mapping. Can use Automapper.
                var dtoFullName = new FullNameDto(fullName);

                return Ok(dtoFullName);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(new NotFoundError("The json was not found"));
            }
            catch (JsonReaderException ex)
            {
                return BadRequest(new InternalServerError("json file is not valid"));
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS
                return BadRequest(new InternalServerError(ex.Message));
            }
        }

        [Route("getFirstNames/{age}/{*filePath}")]
        [HttpGet]
        public async Task<ActionResult<string>> GetFirstNames(string filePath, int age)
        {
            try
            {
                var firstNames = await _jsonParseService.GetFirstNames(filePath, age);
                if (firstNames == null)
                    return NotFound(new NotFoundError($"First names with age {age} not found!"));

                // Mapping. Can use Automapper.
                var dtoFirstNames = new FirstNamesDto(firstNames);
                return Ok(dtoFirstNames);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(new NotFoundError("The json was not found"));
            }
            catch (JsonReaderException ex)
            {
                return BadRequest(new InternalServerError("json file is not valid"));
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS
                return BadRequest(new InternalServerError(ex.Message));
            }
        }

        [Route("getAgeFemaleMale/{*filePath}")]
        [HttpGet]
        public async Task<ActionResult<List<AgeFemaleMaleDto>>> GetAgeFemaleMale(string filePath)
        {
            try
            {
                var ageFemaleMale = await _jsonParseService.GetAgeFemaleMale(filePath);
                if (ageFemaleMale == null || ageFemaleMale.Count == 0)
                    return NotFound(new NotFoundError("No users found"));

                // Mapping. Can use Automapper.
                List<AgeFemaleMaleDto> dtoAgeFemaleMale = new List<AgeFemaleMaleDto>();
                foreach (var item in ageFemaleMale)
                {
                    dtoAgeFemaleMale.Add(new AgeFemaleMaleDto(item.Age, item.Female, item.Male));
                }

                return Ok(dtoAgeFemaleMale);
            }
            catch (DirectoryNotFoundException ex)
            {
                return NotFound(new NotFoundError("The json was not found"));
            }
            catch (JsonReaderException ex)
            {
                return BadRequest(new InternalServerError("json file is not valid"));
            }
            catch (Exception ex)
            {
                // USE A LOGGER SERVICE TO LOG VARIOUS ERRORS
                return BadRequest(new InternalServerError(ex.Message));
            }
        }
    }
}
