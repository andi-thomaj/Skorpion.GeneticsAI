using System.Data;
using Microsoft.Extensions.Options;
using Skorpion.GeneticsAI.Api.Helpers.Options;

namespace Skorpion.GeneticsAI.Api.Data
{
    public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
    {
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(databaseOptions.Value.ConnectionString);
    }
}
