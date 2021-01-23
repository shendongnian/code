        public PropertyInfo MapDestinationPropertyNameToSourceProperty<TSource, TDestination>(string propertyName)
        {
            var typeMap =  GetTypeMap<TSource, TDestination>();
            var sourcePropName = typeMap.GetPropertyMaps().Where(m => m.DestinationProperty.Name == propertyName).Select(x => x.SourceMember.Name).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(sourcePropName))
                return null;
            return typeMap.SourceType.GetProperties().FirstOrDefault(n => n.Name == sourcePropName);            
        }
