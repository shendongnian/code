        public static IEnumerable<TEnum> RangeToInc<TEnum>(this TEnum from, TEnum to) where
            TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (typeof(TEnum).IsEnum)
                return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(
                    a => a.CompareTo(from) >= 0
                        && a.CompareTo(to) <= 0);
            else if (typeof(TEnum).IsNumericType())
            {
                int start = Convert.ToInt32(from);
                int count = Convert.ToInt32(to) - start;
                return Enumerable.Range(start, count + 1).Cast<TEnum>();
            }
            throw new NotImplementedException();
        }
        public static bool IsNumericType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
