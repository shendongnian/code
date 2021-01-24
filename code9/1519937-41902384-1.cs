        public static Enum GetEnum(Type type, int val)
        {
            Enum e = null;
            if (type == typeof(Letter))
            {
                e = (Letter)val;
            }
            else if (type == typeof(Number))
            {
                e = (Number)val;
            }
            return e;
        }
