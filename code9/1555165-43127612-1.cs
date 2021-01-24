        public static object GetTuple<T>(params T[] values)
        {
            Type genericType = Type.GetType("System.Tuple`" + values.Length);
            Type[] typeArgs = values.Select(_ => typeof(T)).ToArray();
            Type specificType = genericType.MakeGenericType(typeArgs);
            object[] constructorArguments = values.Cast<object>().ToArray();
            return Activator.CreateInstance(specificType, constructorArguments);
        }
