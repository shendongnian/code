    public static class MongoExtensions
    {
        public static void Save<T>(this IMongoCollection<T> collection, T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (MongoSaveCommandHelper<T>.ShouldInsert(item))
            {
                collection.InsertOne(item);
            }
            else
            {
                var expression = MongoSaveCommandHelper<T>.GetIdEqualityExpression(item);
                collection.ReplaceOne(expression, item);
            }
        }
        private static class MongoSaveCommandHelper<T>
        {
            private static readonly Expression<Func<T, bool>> IdIsEqualToDefaultExpression;
            private static readonly Func<T, object> GetId;
            public static Func<T, bool> ShouldInsert { get; }
            static MongoSaveCommandHelper()
            {
                var members = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var idProperty = members.SingleOrDefault(x => x.IsDefined(typeof(BsonIdAttribute)))
                                 ?? members.FirstOrDefault(m => m.Name.Equals("id", StringComparison.OrdinalIgnoreCase));
                if (idProperty == null)
                    throw new InvalidOperationException("Id property has not found");
                var idPropertyType = idProperty.PropertyType;
                var parameter = Expression.Parameter(typeof(T));
                var idPropertyAccess = Expression.MakeMemberAccess(parameter, idProperty);
                var getIdFuncExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(idPropertyAccess, typeof(object)), parameter);
                GetId = getIdFuncExpression.Compile();
                IdIsEqualToDefaultExpression = Expression.Lambda<Func<T, bool>>(Expression.Equal(idPropertyAccess, Expression.Default(idPropertyType)), getIdFuncExpression.Parameters);
                ShouldInsert = IdIsEqualToDefaultExpression.Compile();
            }
            public static Expression<Func<T, bool>> GetIdEqualityExpression(T item) => 
                (Expression<Func<T, bool>>)new IdConstantVisitor(GetId(item)).Visit(IdIsEqualToDefaultExpression);
        }
        private class IdConstantVisitor : ExpressionVisitor
        {
            private readonly object _value;
            public IdConstantVisitor(object value) => _value = value;
            protected override Expression VisitDefault(DefaultExpression node) => Expression.Constant(_value, node.Type);
        }
    }
