using Learn_Controller.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Register controllers as services automatically
//builder.Services.AddTransient<HomeController>(); // Register HomeController as a transient service
var app = builder.Build();
app.MapControllers(); // Map controller routes used with builder.Services.AddControllers();

app.MapGet("/", () => "Hello World!");

app.Run();

// 27th Feb --> 6 -- 06:00