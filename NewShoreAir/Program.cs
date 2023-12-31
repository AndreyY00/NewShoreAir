using DB;
using Microsoft.EntityFrameworkCore;
using NewShoreAir.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NewShoreAirContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NewShoreAirConnection")));


var app = builder.Build();
/*DEJAR LA PRIMERA VEZ QUE SE EJECUTA EL PROYECTO*/

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<NewShoreAirContext>();
    context.Database.Migrate();
    string response = await InitialDataController.RequestApi();
    await InitialDataController.SaveData(response, context);
} 

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
