using System.Data;
using Dapper;

namespace TestProject1;

public class QueryObject
{
    readonly IDbConnection _connection;

    public QueryObject(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Dto>> DoQuery()
    {
        var query = $"""
                                 select metadata
                                 from rnc_sequence_features
                                 limit 1;
                     """;

        return await _connection.QueryAsync<Dto>(
            query
        );
    }
}