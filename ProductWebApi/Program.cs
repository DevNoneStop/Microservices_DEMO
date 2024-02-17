using Microsoft.EntityFrameworkCore;
using ProductWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


/* Database Context Dependancy Injection*/

//var dbHost = "127.0.0.1";
//var dbName = "dms_product";
//var dbPassword = "pass@word1";
//var connectioString = $"Server={dbHost};Port=3306;Uid=root;Pwd={dbPassword};Database={dbName};";


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");

//var connectioString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword};TrustServerCertificate=True;Encrypt=False;";
var connectioString = $"Server={dbHost};Port=3306;Uid=root;Pwd={dbPassword};Database={dbName}";

builder.Services.AddDbContext<ProductDBContext>(opt => opt.UseMySQL(connectioString));




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
