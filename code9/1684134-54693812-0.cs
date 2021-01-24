    public class NullableLongHandler : SqlMapper.TypeHandler<long?>
    {
        public override void SetValue(IDbDataParameter parameter, long? value)
        {
            if (value.HasValue)
                parameter.Value = value.Value;
            else
                parameter.Value = DBNull.Value;
        }
        public override long? Parse(object value)
        {
            if (value == null || value is DBNull) return null;
            return Convert.ToInt64(value);
        }
    }
