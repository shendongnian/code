    public IQueryable<Vehicle> GetAccounts(string variant)
    {
        // Build equivalent lambda to 'param => param.{variant} == "Y"'
        // This is lambda parameter
        var param = Expression.Parameter(typeof(Vehicle));
        // This is lambda body (comparison)
        var body = Expression.Equal(
            // Access property {variant} of param
            Expression.Property(param, typeof(Vehicle).GetProperty(variant)),
            // Constant value "Y"
            Expression.Constant("Y")
        );
        // Build lambda using param and body defined above
        var lambda = Expression.Lambda<Func<Vehicle, bool>>(body, param);
        // Use created lambda in query
        return VehicleDatatable.Where(lambda);
    }
