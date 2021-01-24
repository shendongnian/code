        public static object GetTuple(params string[] values)
        {
            Type genericType = Type.GetType("System.Tuple`" + values.Length);
            Type[] typeArgs = values.Select(_ => typeof(string)).ToArray();
            Type specificType = genericType.MakeGenericType(typeArgs);
            return Activator.CreateInstance(specificType, values);
        }
