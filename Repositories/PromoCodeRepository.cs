using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        readonly SqlConnection _connection;
        public PromoCodeRepository(SqlConnection connection) => _connection = connection;
        public async Task<PromoCode?> GetPromoCodeAsync(string promoCode)
        {
            var query = $"SELECT * FROM PROMO_CODES WHERE CODE = {promoCode}";
            return await _connection.QueryFirstAsync<PromoCode>(query, new { code = promoCode });
        }
    }
}
