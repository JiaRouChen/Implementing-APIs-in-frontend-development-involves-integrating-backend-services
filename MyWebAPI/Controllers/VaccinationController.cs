using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using MyWebAPI.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MyWebAPI.Controllers
{
    [Route("apiVaccination")]
    [ApiController]
    public class VaccinationController : ControllerBase
    {
        private readonly ThirdPartDataBuilder _dataBuilder;

        public VaccinationController(ThirdPartDataBuilder dataBuilder)
        {
            _dataBuilder = dataBuilder;
        }


        [HttpGet]
        public async Task<IEnumerable<Vaccination>> Get()
        {

            var data = await _dataBuilder.GetDataFromAPI("https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=34");

            var collection = JsonConvert.DeserializeObject<IEnumerable<Vaccination>>(data);

            return collection;

        }


        [HttpGet("NewPeople")]
        public async Task<IEnumerable<Vaccination>> GetNewPeople()
        {
            var data = await _dataBuilder.GetDataFromAPI("https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=32");

            var collection =  JsonConvert.DeserializeObject<IEnumerable<Vaccination>>(data);

            return collection;

        }

        [HttpGet("Get2")]
        public async Task<IEnumerable<Vaccination>> Get2()
        {
            var data = await _dataBuilder.GetDataFromAPI("https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=38");

            var collection = JsonConvert.DeserializeObject<IEnumerable<Vaccination>>(data);

            return collection;

        }
    }
}
