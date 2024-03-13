using Npgsql;

namespace TestProject1;

public class Manual_DEV_Test : IAsyncLifetime, IDisposable
{
    private readonly NpgsqlDataSource _npgsqlDataSource;

    public Manual_DEV_Test()
    {
        CustomTypeHandlers.Configure();

        var dataSourceBuilder = new NpgsqlDataSourceBuilder("Host=hh-pgsql-public.ebi.ac.uk;Port=5432;Database=pfmegrnargs;Username=reader;Password=NWDMCE5xdipIjRrp;Include Error Detail=true;");
        dataSourceBuilder.EnableDynamicJson();
        dataSourceBuilder.UseJsonNet();
        _npgsqlDataSource = dataSourceBuilder.Build();
    }

    public Task InitializeAsync() => Task.CompletedTask;
    public async Task DisposeAsync() => await _npgsqlDataSource.DisposeAsync();
    

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _npgsqlDataSource.Dispose();
        }
    }

    [Fact]
    public async Task should_run_test()
    {
        var sut = new QueryObject(await _npgsqlDataSource.OpenConnectionAsync());

        // WHEN
        var result = await sut.DoQuery();

        var fiberDto = result.First();
    }
}