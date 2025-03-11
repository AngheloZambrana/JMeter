using Backend.DB.DAOs.Abstract.SingleDAO;
using Backend.DB.DAOs.Concrete;
using Backend.DB.Utils;
using Backend.Services;
using Backend.Services.Interfaces;
using Microsoft.OpenApi.Models;

DBConnector.GetConnection();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Work", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:3000")  
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpClient();

builder.Services.AddScoped<IProductsDAO, ProductsDAO>();
builder.Services.AddScoped<IProductsServices, ProductsServices>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Work v1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("AllowLocalhost");  

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();