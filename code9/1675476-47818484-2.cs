    public static class MongoExtensions
    {
        public static void Save<T>(this IMongoCollection<T> collection, T item)
        {
            var id = IdFuncHolder<T>.GetId(item);
            if (id == null)
            {
                collection.InsertOne(item);
            }
            else
            {
                var expression = IdFuncHolder<T>.GetIdEqualityExpression(id);
                collection.ReplaceOne(expression, item);
            }
        }
        private static class IdFuncHolder<T>
        {
            private static readonly Expression<Func<T, bool>> IdEqualityExpression;
            public static Func<T, object> GetId { get; }
            static IdFuncHolder()
            {
                var members = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var idProperty = members.SingleOrDefault(x => x.IsDefined(typeof(BsonIdAttribute)))
                                 ?? members.FirstOrDefault(m => m.Name.Equals("id", StringComparison.OrdinalIgnoreCase));
                if (idProperty == null)
                    throw new InvalidOperationException("Cannot find single ID property.");
                var idPropertyType = idProperty.PropertyType;
                var parameter = Expression.Parameter(typeof(T));
                var idPropertyAccess = Expression.MakeMemberAccess(parameter, idProperty);
                var getIdFuncExpression = Expression.Lambda<Func<T, object>>(
                    Expression.Convert(idPropertyAccess, typeof(object))
                    , parameter);
                GetId = getIdFuncExpression.Compile();
                IdEqualityExpression = Expression.Lambda<Func<T, bool>>(Expression.Equal(idPropertyAccess, Expression.Default(idPropertyType)), getIdFuncExpression.Parameters);
            }
            public static Expression<Func<T, bool>> GetIdEqualityExpression(object id) => 
                (Expression<Func<T, bool>>)new IdConstantVisitor(id).Visit(IdEqualityExpression);
        }
        private class IdConstantVisitor : ExpressionVisitor
        {
            private readonly object _value;
            public IdConstantVisitor(object value) => _value = value;
            protected override Expression VisitDefault(DefaultExpression node) => Expression.Constant(_value, node.Type);
        }
    }
