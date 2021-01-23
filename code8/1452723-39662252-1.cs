    public static class OperationTypeEnumExtensions
    {
        public static T ToEnum<T>(this byte val) where T : struct
        {
            if(Enum.IsDefined(typeof(T), val)) 
                return (T) Enum.Parse(typeof(T), val.ToString());
            return default(T);
        }
    }
