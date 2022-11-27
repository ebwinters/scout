using Microsoft.Azure.Cosmos;
using scout;
using Scout.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CosmosClient>(serviceProvider =>
{
    var accountEndpoint = builder.Configuration.GetSection("CosmosDbClientSettings").GetValue<string>("AccountEndpoint");
    return new CosmosClient(accountEndpoint);
});

var key = builder.Configuration.GetValue<string>("Key");
builder.Services.AddSingleton<Settings>(new Settings() { Key = key });
builder.Services.AddSingleton<CosmosDbContainerSettings>();
builder.Services.Configure<CosmosDbContainerSettings>(builder.Configuration.GetSection("CosmosDbClientSettings"));
builder.Services.AddScoped<ScoutRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
