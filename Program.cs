using DependencyStore.Extensions;
using DependencyStore.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddConfiguration();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>());
builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, PrimaryService>());
//builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IService, SecondaryService>());

var descriptor = new ServiceDescriptor(typeof(IService), typeof(PrimaryService), ServiceLifetime.Transient);
builder.Services.TryAddEnumerable(descriptor);

var app = builder.Build();

app.MapGet("/", (IEnumerable<IService> services) =>
     Results.Ok(services.Select(x => x.GetType().Name))
);

app.MapControllers();

app.Run();

public interface IService
{
}