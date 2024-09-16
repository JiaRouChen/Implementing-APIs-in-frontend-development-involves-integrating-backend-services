using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//2.1.5 在Program.cs加入使用appsettings.json中的連線字串程式碼(這段必須寫在var builder這行後面)
builder.Services.AddDbContext<dbStudentsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbStudentsConnection")));


//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//註冊httpClient服務
builder.Services.AddHttpClient();

//註冊ThirdPartDataBuilder服務
builder.Services.AddScoped<ThirdPartDataBuilder>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
