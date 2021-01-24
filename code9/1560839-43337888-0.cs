        public static int Insert<T>(this IDbConnection connection, T param)
        {
            if (typeof(T).GetInterfaces()
              .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)))
            {
                // method info retrieval should be written more carefully & cached in static var
                var method = MethodBase.GetCurrentMethod().DeclaringType.GetMethods()
                  .Single(m => m.Name == "Insert" && m.GetParameters()
                    .Select(p => p.ParameterType)
                    .Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IList<>)));
                var generic = method.MakeGenericMethod(typeof(T).GenericTypeArguments[0]);
                return (int)generic.Invoke(null, new object[] { connection, param });
            }
            ...
        }
