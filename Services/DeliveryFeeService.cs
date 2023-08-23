using DependencyStore.Services.Contracts;
using RestSharp;

namespace DependencyStore.Services
{
    public class DeliveryFeeService : IDeliveryFeeService
    {
        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            var client = new RestClient("https://consultafrete.io/cep/");
            var request = new RestRequest()
                .AddJsonBody(new
                {
                    zipCode
                });
            var deliveryFee = await client.PostAsync<decimal>(request);
            // Nunca é menos que R$ 5,00
            return deliveryFee < 5 ? 5 : deliveryFee;
        }      
    }
}
