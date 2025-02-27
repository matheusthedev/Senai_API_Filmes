using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adicionar o repositorio e a interface ao container da injeção de dependencia
builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();

//Adicionar o serviço de controladores
builder.Services.AddControllers();

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

var app = builder.Build();

//Adicionar o mapeamento dos controllers
app.MapControllers();

app.Run();