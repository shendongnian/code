    public static async Task<Expression<Func<TSource, object>>> BuildExceptKeySelectorAsync<TSource, TXKey>(Expression<Func<TSource, TXKey>> exceptKeySelector)
    {
        var exclude = typeof(TXKey).GetProperties()
            .Select(p => (p.PropertyType, p.Name))
            .ToHashSet();
        var properties =
            (from p in typeof(TSource).GetProperties()
            where !exclude.Contains((p.PropertyType, p.Name))
            select p).ToList();
        var targetType = await CreateTypeWithPropertiesAsync(
            properties.Select(p => (p.PropertyType, p.Name))
        );
        var itemExpr = Expression.Parameter(typeof(TSource));
        var keyExpr = Expression.New(
            targetType.GetConstructors().Single(),
            properties.Select(p => Expression.Property(itemExpr, p)),
            targetType.GetProperties()
        );
        return Expression.Lambda<Func<TSource, object>>(keyExpr, itemExpr);
        async Task<Type> CreateTypeWithPropertiesAsync(IEnumerable<(Type type, string name)> properties) =>
            (await CSharpScript.EvaluateAsync<object>(
                AnonymousObjectCreationExpression(
                    SeparatedList(
                        properties.Select(p =>
                            AnonymousObjectMemberDeclarator(
                                NameEquals(p.name),
                                DefaultExpression(ParseTypeName(p.type.FullName))
                            )
                        )
                    )
                ).ToFullString()
            )).GetType();
    }
