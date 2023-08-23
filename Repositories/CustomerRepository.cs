using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;

public class CustomerRepository : ICustomerRepository
{
    readonly SqlConnection _connection;
    public CustomerRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    public async Task<Customer?> GetByIdAsync(string customerId)
    {
        await using (var conn = new SqlConnection("CONN_STRING"))
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
            return await _connection
                    .QueryFirstAsync<Customer>(query, new { id = customerId });
        }
    }
}
