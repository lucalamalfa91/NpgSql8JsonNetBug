using System.Data;
using Dapper;

namespace TestProject1;

public class ObjectTypeHandler : SqlMapper.TypeHandler<Object>
{
    public override string Parse(Object value)
    {
        return "test";
    }

    public override void SetValue(IDbDataParameter parameter, Object value) =>
        parameter.Value = value;
}
