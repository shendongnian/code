    public class NumericTypeHandler : SqlMapper.TypeHandler<decimal>
    {
        public override void SetValue(IDbDataParameter parameter, decimal value)
        {
            parameter.Value = (long)(value / 10000);
        }
        public override decimal Parse(object value)
        {
            return ((decimal)value)/10000M;
        }
    }
