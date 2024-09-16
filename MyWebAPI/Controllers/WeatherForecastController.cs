using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}



//MyWebAPI專案進行步驟

//1     製作我的第一個Restful API(Web API)

//1.1   建立CRUD API Ccontroller 
//1.1.1 在Controllers資料夾上按右鍵→加入→控制器
//1.1.2 左側選單點選「API」→ 中間主選單選擇「執行讀取/寫入動作的API控制器」→按下「加入」鈕
//1.1.3 檔名使用預設的ValuesController.cs 即可，按下「新增」鈕
//      ※我們會得到一個已經撰寫好基本CRUD架構的API Ccontroller※
//      ※該Ccontroller的撰寫風格符合Rest，使用Get、Get/{id}、Post、Put、Delete 進行各項動作※

//1.2   安裝Swagger Tool(如果有需要的話)
//1.2.1 使用NuGet(專案名稱上按右鍵→管理NuGet套件)安裝Swashbuckle.AspNetCore套件
//1.2.2 在Program.cs中註冊及啟用Swagger
//1.2.3 安裝完後請執行本專案讓伺服器執行
//1.2.4 在網址列輸入http://localhost:xxxx/swagger/index.html (其中xxxx是您的port)
//1.2.5 測試及瞭解Swagger
//      ※Swagger是由一家叫SmartBear的公司所發行，屬於無償使用的OpenAPI套件，以使用於API開發時的測試※
//      ※以往開發多使用Postman這個軟體進行API測試，目前Swagger成為主流※   
//////////////////////////////////////////////////////////////////////////////////////////////////
//1.2.6 修改Post、Put及Delete Action
//1.2.7 使用Swagger Tool來進行ValuesController API的操作測試
//      ※Web API因為沒有UI，所以只能就Get的動作進行測試，無法對Post、Put及Delete的動作進行測試※ 
//      ※因此這裡的操作目的是熟悉Swagger的用法，以利Web API在開發時能使用它來進行測試※


//2     使用DB First建立 Model

//2.1   建立專案與資料庫的連線
//2.1.1 使用NuGet(專案名稱上按右鍵→管理NuGet套件)安裝下列套件
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools
//2.1.2 建立Models資料夾
//2.1.3 到套件管理器主控台(檢視 > 其他視窗 > 套件管理器主控台)下指令
//      Scaffold-DbContext "Data Source=伺服器位址;Database=資料庫名稱;TrustServerCertificate=True;User ID=帳號;Password=密碼" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -UseDatabaseNames -NoPluralize -Force
//      若成功的話，會看到Build succeeded.字眼，並在Models資料夾裡看到dbStudentsContext.cs(描述資料庫)及tStudent.cs(描述資料表)
//2.1.4 將連線字串寫在appsettings.json檔中
//2.1.5 在Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫在var builder這行後面)


//3     製作tStudent資料CRUD 的 Restful API(Web API)

//3.1   建立Department API Ccontroller 
//3.1.1 在Controllers資料夾上按右鍵→加入→控制器
//3.1.2 左側選單點選「API」→ 中間主選單選擇「使用Entity Framework執行動作的API控制器」→按下「加入」鈕
//3.1.3 在對話方塊中設定如下
//      模型類別: Department(MyWebAPI.Models)
//      資料內容類別: dbStudentsContext(MyWebAPI.Models)
//      控制器名稱使用預設即可(DepartmentsController)
//      按下「新增」鈕
//3.1.4 修改API介接路由為「apiDepartment」


//3.2   建立tStuden API Ccontroller 
//3.2.1 在Controllers資料夾上按右鍵→加入→控制器
//3.2.2 左側選單點選「API」→ 中間主選單選擇「使用Entity Framework執行動作的API控制器」→按下「加入」鈕
//3.2.3 在對話方塊中設定如下
//      模型類別: tStudent(MyWebAPI.Models)
//      資料內容類別: dbStudentsContext(MyWebAPI.Models)
//      控制器名稱使用預設即可(tStudentsController)
//      按下「新增」鈕
// 3.2.4 修改API介接路由為「apiStudent」

//使用Swagger Tool分別對DepartmentsController及tStudentsController API進行操作測試


////////////////////這條是前後端工程師分隔線////////////////////////////////


