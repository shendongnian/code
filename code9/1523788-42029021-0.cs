        public static bool IsClassGeneric<T>(T value = default(T))
        {
            return IsClassGeneric(typeof(T));
        }
        public static bool IsClassGeneric(Type type)
        {
            return type.DeclaringMethod == null;
        }
