            Mapper.Initialize(expression =>
            {
                expression.ShouldMapProperty = info => !(
                    info.PropertyType.IsGenericType && 
                    info.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
                expression.CreateMap<Bar, Bar>();
                expression.CreateMap<EmbeddedInBar, EmbeddedInBar>();
            });
            Mapper.Map(source, destination);
