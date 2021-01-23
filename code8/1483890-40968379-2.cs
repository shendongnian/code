        public static void RegisterTypeMaps()
        {
            var mappedTypes = Assembly.GetAssembly(typeof (Initiator)).GetTypes().Where(
                f =>
                f.GetProperties().Any(
                    p =>
                    p.GetCustomAttributes(false).Any(
                        a => a.GetType().Name == ColumnAttributeTypeMapper<dynamic>.ColumnAttributeName)));
            var mapper = typeof(ColumnAttributeTypeMapper<>);
            foreach (var mappedType in mappedTypes)
            {
                var genericType = mapper.MakeGenericType(new[] { mappedType });
                SqlMapper.SetTypeMap(mappedType, Activator.CreateInstance(genericType) as SqlMapper.ITypeMap);
            }
        }
