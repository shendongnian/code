    typeof(MultiTenantHandler<,>).IsCompatibleWithGenericParameterConstraints(new[] { typeof(IQueryable<Game>), typeof(IQueryable<Game>) }); // expected: true
    typeof(MultiTenantHandler<,>).IsCompatibleWithGenericParameterConstraints(new[] { typeof(IQueryable<Trophy>), typeof(IQueryable<Trophy>) }); // expected: false
    
    typeof(MultiTenantOptionalHandler<,>).IsCompatibleWithGenericParameterConstraints(new[] { typeof(IQueryable<Game>), typeof(IQueryable<Game>) }); // expected: false
    typeof(MultiTenantOptionalHandler<,>).IsCompatibleWithGenericParameterConstraints(new[] { typeof(IQueryable<Trophy>), typeof(IQueryable<Trophy>) }); // expected: true
