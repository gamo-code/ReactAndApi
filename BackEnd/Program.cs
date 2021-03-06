var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddCors();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseCors(
//  x => x
//  .AllowAnyMethod()
//  .AllowAnyHeader()
//  .SetIsOriginAllowed(origin => true) // allow any origin
//  .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
