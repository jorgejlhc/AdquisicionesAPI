using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext
builder.Services.AddDbContext<AdquisicionesContext>(options => options.UseInMemoryDatabase("AdquisicionesDB"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Adquisiciones",
        Version = "v1",
        Description = "API para la gestión de adquisiciones de bienes y servicios",
        Contact = new OpenApiContact
        {
            Name = "Jorge Luis Hernández Cañón",
            Email = "jorgejlhc@gmail.com"
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IAdquisicionesService, AdquisicionesService>();
builder.Services.AddScoped<IHistorialService, HistorialService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Adquisiciones v1");
        c.RoutePrefix = ""; // Para que cargue en la raíz
    });
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();