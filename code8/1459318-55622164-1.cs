public class DbClass
{
  static DbClass()
  {
    SqlMapper.AddTypeHandler(new MyPostgresEnumTypeHandler());
  }
  
  class MyPostgresEnumTypeHandler : SqlMapper.TypeHandler<MyPostgresEnum>
  {
    public override MyPostgresEnum Parse(object value)
    {
      switch (value)
      {
        case int i: return (MyPostgresEnum)i;
        case string s: return (MyPostgresEnum)Enum.Parse(typeof(MyPostgresEnum),s);
        default: throw new NotSupportedException($"{value} not a valid MyPostgresEnum value");
      }
    }
    public override void SetValue(IDbDataParameter parameter, MyPostgresEnum value)
    {
      parameter.DbType = (DbType)NpgsqlDbType.Unknown;
      // assuming the enum case names match the ones defined in Postgres
      parameter.Value = Enum.GetName(typeof(MyPostgresEnum), (int)value).ToString().ToLowerInvariant(); 
    }
  }
}
Unfortunately, this doesn't work because Dapper ignores custom type handlers for Enums, specifically.  See https://github.com/StackExchange/Dapper/issues/259 for details.
My approach while waiting to see if this issue is ever dealt with is going to be to write `NpgsqlCommand` queries directly when dealing with these kinds of enums.
