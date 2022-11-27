using Microsoft.Azure.Cosmos;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore.Cosmos;
using Scout.Api;
using Scout.Infrastructure;
using Scout.Infrastructure.EntityDataModels;
using Scout.Infrastructure.Entities;
using Scout.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddOData(opt => opt
        .AddRouteComponents("odata", new ScoutEntityDataModel().GetEntityDataModel())
        .Select()
        .Expand()
        .OrderBy()
        .SetMaxTop(10)
        .Count()
        .Filter());
builder.Services.AddDbContext<ScoutContext>(opt => opt.UseCosmos(
        builder.Configuration.GetSection("CosmosDbClientSettings").GetValue<string>("AccountEndpoint"),
        builder.Configuration.GetSection("CosmosDbClientSettings").GetValue<string>("DatabaseName"),
        opt => new CosmosClientOptions
        {
             SerializerOptions = new()
             {
                 PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase,
                 IgnoreNullValues = true
             }
        }
    ));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = builder.Configuration.GetValue<string>("Key");
builder.Services.AddSingleton<Settings>(new Settings() { Key = key });
builder.Services.AddSingleton<CosmosDbContainerSettings>();
builder.Services.Configure<CosmosDbContainerSettings>(builder.Configuration.GetSection("CosmosDbClientSettings"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
