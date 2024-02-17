using CustomerAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



/* Database Context Dependancy Injection*/

//var dbHost = "(localdb)\\local";
//var dbName = "dms_customer";
//var dbPassword = "Pa$$~word1";
//var connectioString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";


var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectioString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword};TrustServerCertificate=True;Encrypt=False;";


builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectioString));




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization(); 

app.MapControllers();

app.Run();
