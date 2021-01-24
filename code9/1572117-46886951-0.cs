    class DictTypeHandler : ITypeHandler
    {
        public object Parse(Type destinationType, object value)
        {
            return JsonConvert.DeserializeObject<Dictionary<int, string>>(value.ToString());
        }
        public void SetValue(IDbDataParameter parameter, object value)
        {
            parameter.Value = (value == null)
                ? (object)DBNull.Value
                : JsonConvert.SerializeObject(value);
            parameter.DbType = DbType.String;
        }
    }
