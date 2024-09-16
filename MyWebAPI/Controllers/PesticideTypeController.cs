using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesticideTypeController : ControllerBase
    {
        private readonly ThirdPartDataBuilder _dataBuilder;

        public PesticideTypeController(ThirdPartDataBuilder dataBuilder)
        {
            _dataBuilder = dataBuilder;
        }


        [HttpGet]
        public async Task<IEnumerable<Data>> Get()
        {

            var data = await _dataBuilder.GetDataFromAPI("https://data.moa.gov.tw/api/v1/PesticideType/");

            PesticideType collection = JsonConvert.DeserializeObject<PesticideType>(data);

            return collection.Data;

        }

    }
}
