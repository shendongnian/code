    a => a.GetName().Name == "Trading" ? typeof(Trading.Control.Json.TradingConfig).Assembly : null;
    /// <summary>
    ///     Uses the func to resolve assembly instances by name, since they may be in a different directory and not
    ///     directly resolvable by Assembly.Load (the default method used by JSON.NET)
    /// </summary>
    internal class SerializationBinder : DefaultSerializationBinder
    {
        private readonly Func<string, Assembly> assemblyResolver;
        public SerializationBinder(Func<string, Assembly> assemblyResolver)
        {
            this.assemblyResolver = assemblyResolver;
        }
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly assembly;
            try
            {
                assembly = assemblyResolver(assemblyName);
            }
            catch
            {
                // not registered
                return base.BindToType(assemblyName, typeName);
            }
            var type = assembly.GetType(typeName);
            if (type == null)
                type = GetGenericTypeFromTypeName(typeName, assembly);
            if (type != null) return type;
            return base.BindToType(assemblyName, typeName);
        }
        /// <summary>
        ///     From DefaultSerializationBinder.
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        private Type GetGenericTypeFromTypeName(string typeName, Assembly assembly)
        {
            Type type1 = null;
            var length = typeName.IndexOf('[');
            if (length >= 0)
            {
                var name = typeName.Substring(0, length);
                var type2 = assembly.GetType(name);
                if (type2 != null)
                {
                    var typeList = new List<Type>();
                    var num1 = 0;
                    var startIndex = 0;
                    var num2 = typeName.Length - 1;
                    for (var index = length + 1; index < num2; ++index)
                        switch (typeName[index])
                        {
                            case '[':
                                if (num1 == 0)
                                    startIndex = index + 1;
                                ++num1;
                                break;
                            case ']':
                                --num1;
                                if (num1 == 0)
                                {
                                    typeName = SplitFullyQualifiedTypeName(typeName.Substring(startIndex, index - startIndex));
                                    return Type.GetType(typeName);
                                }
                                break;
                        }
                    type1 = type2.MakeGenericType(typeList.ToArray());
                }
            }
            return type1;
        }
        /// <summary>
        ///     From Reflectionutils
        /// </summary>
        /// <param name="fullyQualifiedTypeName"></param>
        /// <returns></returns>
        private static string SplitFullyQualifiedTypeName(string fullyQualifiedTypeName)
        {
            var assemblyDelimiterIndex = GetAssemblyDelimiterIndex(fullyQualifiedTypeName);
            string typeName;
            if (assemblyDelimiterIndex.HasValue)
                typeName = Trim(fullyQualifiedTypeName, 0, assemblyDelimiterIndex.GetValueOrDefault());
            else
                typeName = fullyQualifiedTypeName;
            return typeName;
        }
        /// <summary>
        ///     From Reflectionutils
        /// </summary>
        /// <param name="fullyQualifiedTypeName"></param>
        /// <returns></returns>
        private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName)
        {
            var num = 0;
            for (var index = 0; index < fullyQualifiedTypeName.Length; ++index)
                switch (fullyQualifiedTypeName[index])
                {
                    case ',':
                        if (num == 0)
                            return index;
                        break;
                    case '[':
                        ++num;
                        break;
                    case ']':
                        --num;
                        break;
                }
            return new int?();
        }
        private static string Trim(string s, int start, int length)
        {
            if (s == null)
                throw new ArgumentNullException();
            if (start < 0)
                throw new ArgumentOutOfRangeException("start");
            if (length < 0)
                throw new ArgumentOutOfRangeException("length");
            var index = start + length - 1;
            if (index >= s.Length)
                throw new ArgumentOutOfRangeException("length");
            while (start < index && char.IsWhiteSpace(s[start]))
                ++start;
            while (index >= start && char.IsWhiteSpace(s[index]))
                --index;
            return s.Substring(start, index - start + 1);
        }
    }
`
