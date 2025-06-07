using ApiKolokwium.Data;
using ApiKolokwium.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite("Data Source=example.db"));
builder.Services.AddScoped<IDbService, DbService>();
var app = builder.Build();



app.UseAuthorization();

app.MapControllers();

app.Run();