        public static IEnumerable<TEnum> RangeToInc<TEnum>(this TEnum from, TEnum to) where 
            TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(
                a => a.CompareTo(from) >= 0 
                    && a.CompareTo(to) <= 0).ToArray(); //Actually it does not need ToArray
            
        }
