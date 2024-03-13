using Dapper;

namespace TestProject1;

public static class CustomTypeHandlers
{
    public static void Configure()
    {
        SqlMapper.AddTypeHandler(new ObjectTypeHandler());
    }
}
