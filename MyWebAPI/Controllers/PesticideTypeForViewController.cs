using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{
    public class PesticideTypeForViewController : Controller
    {
        private readonly ThirdPartDataBuilder _dataBuilder;

        public PesticideTypeForViewController(ThirdPartDataBuilder dataBuilder)
        {
            _dataBuilder = dataBuilder;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _dataBuilder.GetDataFromAPI("https://data.moa.gov.tw/api/v1/PesticideType/");

            PesticideType collection = JsonConvert.DeserializeObject<PesticideType>(data);

            return View(collection.Data.ToList());
        }
    }
}
