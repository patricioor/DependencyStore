using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using Microsoft.Data.SqlClient;
using DependencyStore.Services.Contracts;
using DependencyStore.Services;

namespace DependencyStore.Extensions
{
    public static class DepedenciesExtension
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            //Cria uma instância e permanece com ela na memória até o programa ser finalizado.
            services.AddSingleton<Configuration>();
        }
        public static void AddSqlConnection(this IServiceCollection services, IConfiguration configuration)
        {
            //Cria uma instância e guarda ela até finalizar a ação
            var connStr = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped(x => new SqlConnection(connStr));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            //Cria uma nova instância toda vez que for executado
            var promoCode = new ServiceDescriptor(typeof(IPromoCodeRepository), typeof(PromoCodeRepository), ServiceLifetime.Scoped);
            services.Add(promoCode);
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}
