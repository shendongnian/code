    void Configure(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ProtoThings, HasListOfThings>().ReverseMap();
        bool IsToRepeatedField(PropertyMap pm)
        {
            if (pm.DestinationPropertyType.IsConstructedGenericType)
            {
                var destGenericBase = pm.DestinationPropertyType.GetGenericTypeDefinition();
                return destGenericBase == typeof(RepeatedField<>);
            }
            return false;
        }
        cfg.ForAllPropertyMaps(IsToRepeatedField, (propertyMap, opts) => opts.UseDestinationValue());
    }
