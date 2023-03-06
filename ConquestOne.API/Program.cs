using ConquestOne.Application.Interfaces;
using ConquestOne.Application.Receivers;
using ConquestOne.Domain.Entities;
using ConquestOne.Infrastructure.Factory;
using ConquestOne.Infrastructure.Repositories;
using ConquestOne.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SqlFactory>();
builder.Services.AddTransient<IFinanceRepository, FinanceRepository>();
builder.Services.AddTransient<IFinanceService, FinanceService>();
builder.Services.AddTransient<InsertReceiver>();

var app = builder.Build();

app.MapGet("YahooFinance/PETR4/GetInformations/", ([FromServices] IFinanceRepository repository) => 
{
    return repository.GetAll();
});

app.MapPost("/YahooFinance/PETR4/Insert/", ([FromServices]InsertReceiver receiver, [FromBody] List<PETR4Entity> dto) => 
{
    return receiver.Action(dto);
});

app.MapGet("/YahooFinance/PETR4/Historic30Days/", ([FromServices] IFinanceRepository repository) =>
{
    return repository.GetHistoric30Days();
});

app.Run();