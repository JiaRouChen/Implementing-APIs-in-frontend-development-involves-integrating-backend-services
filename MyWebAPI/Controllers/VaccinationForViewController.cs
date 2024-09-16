using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebAPI.Models;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{
    public class VaccinationForViewController : Controller
    {

        private readonly ThirdPartDataBuilder _dataBuilder;

        public VaccinationForViewController(ThirdPartDataBuilder dataBuilder)
        {
            _dataBuilder = dataBuilder;
        }

        public async Task<IActionResult> Index()
        {

            var data = await _dataBuilder.GetDataFromAPI("https://covid-19.nchc.org.tw/2023_dt_json.php?dt_name=34");
            var collection = JsonConvert.DeserializeObject<IEnumerable<Vaccination>>(data);

            return View(collection);
        }
    }
}
