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



//MyWebAPI�M�׶i��B�J

//1     �s�@�ڪ��Ĥ@��Restful API(Web API)

//1.1   �إ�CRUD API Ccontroller 
//1.1.1 �bControllers��Ƨ��W���k����[�J�����
//1.1.2 ��������I��uAPI�v�� �����D����ܡu����Ū��/�g�J�ʧ@��API����v�����U�u�[�J�v�s
//1.1.3 �ɦW�ϥιw�]��ValuesController.cs �Y�i�A���U�u�s�W�v�s
//      ���ڭ̷|�o��@�Ӥw�g���g�n��CRUD�[�c��API Ccontroller��
//      ����Ccontroller�����g����ŦXRest�A�ϥ�Get�BGet/{id}�BPost�BPut�BDelete �i��U���ʧ@��

//1.2   �w��Swagger Tool(�p�G���ݭn����)
//1.2.1 �ϥ�NuGet(�M�צW�٤W���k����޲zNuGet�M��)�w��Swashbuckle.AspNetCore�M��
//1.2.2 �bProgram.cs�����U�αҥ�Swagger
//1.2.3 �w�˧���а��楻�M�������A������
//1.2.4 �b���}�C��Jhttp://localhost:xxxx/swagger/index.html (�䤤xxxx�O�z��port)
//1.2.5 ���դ��A��Swagger
//      ��Swagger�O�Ѥ@�a�sSmartBear�����q�ҵo��A�ݩ�L�v�ϥΪ�OpenAPI�M��A�H�ϥΩ�API�}�o�ɪ����ա�
//      ���H���}�o�h�ϥ�Postman�o�ӳn��i��API���աA�ثeSwagger�����D�y��   
//////////////////////////////////////////////////////////////////////////////////////////////////
//1.2.6 �ק�Post�BPut��Delete Action
//1.2.7 �ϥ�Swagger Tool�Ӷi��ValuesController API���ާ@����
//      ��Web API�]���S��UI�A�ҥH�u��NGet���ʧ@�i����աA�L�k��Post�BPut��Delete���ʧ@�i����ա� 
//      ���]���o�̪��ާ@�ت��O���xSwagger���Ϊk�A�H�QWeb API�b�}�o�ɯ�ϥΥ��Ӷi����ա�


//2     �ϥ�DB First�إ� Model

//2.1   �إ߱M�׻P��Ʈw���s�u
//2.1.1 �ϥ�NuGet(�M�צW�٤W���k����޲zNuGet�M��)�w�ˤU�C�M��
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools
//2.1.2 �إ�Models��Ƨ�
//2.1.3 ��M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      Scaffold-DbContext "Data Source=���A����};Database=��Ʈw�W��;TrustServerCertificate=True;User ID=�b��;Password=�K�X" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -UseDatabaseNames -NoPluralize -Force
//      �Y���\���ܡA�|�ݨ�Build succeeded.�r���A�æbModels��Ƨ��̬ݨ�dbStudentsContext.cs(�y�z��Ʈw)��tStudent.cs(�y�z��ƪ�)
//2.1.4 �N�s�u�r��g�bappsettings.json�ɤ�
//2.1.5 �bProgram.cs�[�J�ϥ�appsettings.json�����s�u�r��{���X(�o�q�����g�bvar builder�o��᭱)


//3     �s�@tStudent���CRUD �� Restful API(Web API)

//3.1   �إ�Department API Ccontroller 
//3.1.1 �bControllers��Ƨ��W���k����[�J�����
//3.1.2 ��������I��uAPI�v�� �����D����ܡu�ϥ�Entity Framework����ʧ@��API����v�����U�u�[�J�v�s
//3.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Department(MyWebAPI.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyWebAPI.Models)
//      ����W�٨ϥιw�]�Y�i(DepartmentsController)
//      ���U�u�s�W�v�s
//3.1.4 �ק�API�������Ѭ��uapiDepartment�v


//3.2   �إ�tStuden API Ccontroller 
//3.2.1 �bControllers��Ƨ��W���k����[�J�����
//3.2.2 ��������I��uAPI�v�� �����D����ܡu�ϥ�Entity Framework����ʧ@��API����v�����U�u�[�J�v�s
//3.2.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: tStudent(MyWebAPI.Models)
//      ��Ƥ��e���O: dbStudentsContext(MyWebAPI.Models)
//      ����W�٨ϥιw�]�Y�i(tStudentsController)
//      ���U�u�s�W�v�s
// 3.2.4 �ק�API�������Ѭ��uapiStudent�v

//�ϥ�Swagger Tool���O��DepartmentsController��tStudentsController API�i��ާ@����


////////////////////�o���O�e��ݤu�{�v���j�u////////////////////////////////


