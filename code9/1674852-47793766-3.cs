    public static IMappingOperationOptions SubstituteMappingOptions<TMapSource, TMapDestination>(this IMapper mapperSubstitute, out Action<IMappingOperationOptions> optionsArgument)
    {
        Action<IMappingOperationOptions> argumentUsed = null;
        mapperSubstitute.Map<TMapDestination>(Arg.Any<TMapSource>(),
            Arg.Do<Action<IMappingOperationOptions>>(arg => argumentUsed = arg));
    
        optionsArgument = argumentUsed;
        return Substitute.For<IMappingOperationOptions>();
    }
