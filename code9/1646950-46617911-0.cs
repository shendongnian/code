        public static IList<T> GetFlaggedValues<T>(ulong intValue) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            var flagAttrib = Attribute.GetCustomAttribute(typeof(T), typeof(FlagsAttribute));
            if(flagAttrib==null)
            {
                throw new ArgumentException("T must have [Flags] attribute.");
            }
            List<T> vals = new List<T>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var item = Convert.ToUInt64(e);
                if ((item & intValue) != 0)
                    vals.Add((T)Enum.ToObject(typeof(T), item));
            }
            return vals;
        }
