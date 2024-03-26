using API.Models;
using Application.Interface.Services;
using Application.Services;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Context;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var services = builder.Services;

services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

//SERVICES
services.AddScoped<IProductService, ProductService>();

//REPOSITORIES
services.AddScoped<IProductRepository, ProductRepository>();

services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<Produto, ProdutoModel>();
    config.CreateMap<ProdutoModel, Produto>();
    config.CreateMap<EditProdutoModel, Produto>();
}).CreateMapper());


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
