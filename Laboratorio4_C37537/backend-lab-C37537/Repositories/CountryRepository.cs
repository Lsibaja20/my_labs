using backend_lab_C37537.Model;
using System.Data;
using System.Data.SqlClient;

namespace backend_lab_C37537.Repositories
{
    using backend_lab_C37537.Model;
    using Dapper;
    using System.Data.SqlClient;

    public class CountryRepository
    {
        private readonly string _connectionString;

        public CountryRepository()
        {
            var builder = WebApplication.CreateBuilder();
            _connectionString =
                builder.Configuration.GetConnectionString("CountryContext");
        }

        public List<CountryModel> GetCountries()
        {
            using var connection = new SqlConnection(_connectionString);
            string query = "SELECT * FROM dbo.Country";
            return connection.Query<CountryModel>(query).ToList();
        }
    }
}
