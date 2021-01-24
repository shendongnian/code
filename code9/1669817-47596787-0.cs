        public static string GetEnumName(object o)
        {
            if (o is Foo)
                return o.GetType().Name;
            return null;
        }
        public static string GetName(object o)
        {
            if (o is Foo)
            {
                return Enum.GetName(typeof(Foo), o);
            }
            return null;
        }
