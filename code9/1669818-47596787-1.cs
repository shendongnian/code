        public static string GetEnumName(object o)
        {
            if ( o is Enum)
                return o.GetType().Name;
            return null;
        }
        public static string GetName(object o)
        {
            if (o is Enum)
            {
                return Enum.GetName(o.GetType(), o);
            }
            return null;
        }
