using Prueba_Tecnica.Data;
using Prueba_Tecnica.Data.Repositorio;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySQLConfiguration = new MySqlConfiguracion(builder.Configuration.GetConnectionString("MySqlContection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<iCategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<iProductoRepositorio, ProductoRepositorio>();

var app = builder.Build();

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
