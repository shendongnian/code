    public interface IDb { }
    
    [MapConfig("TableName", "Schema")]
    public class DbTemp : IDb
    {
        public string Title { get; set; }
    }
    
    public class MapConfigAttribute : Attribute
    {
        public MapConfigAttribute(string name, string schema)
        {
            Name = name;
            Schema = schema;
        }
        public string Name { get; }
        public string Schema { get; }
    }
    
    public sealed class DbMapper : ClassMapper<IDb>
    {
        public DbMapper()
        {
            DapperExstensionsExstensions.CorrespondingTypeMapper<IDb>((tableName, sechemaName, exprs) =>
            {
                Table(tableName);
                Schema(SchemaName);
                return exprs.Select(Map);
            });
        }
    }
    
    public static class DapperExstensionsExstensions
    {
        private static readonly object _LOCK = new object();
        public static Type SharedState_ModelInstanceType { get; set; }
        public static List<PropertyMap> CorrespondingTypeMapper<T>(Func<string, string, IEnumerable<Expression<Func<T, object>>>, IEnumerable<PropertyMap>> callback)
        {
            var tableNameAttribute = (MapConfigAttribute)SharedState_ModelInstanceType.GetCustomAttribute(typeof(MapConfigAttribute));
            var tableName = tableNameAttribute.Name;
            var schemaName = tableNameAttribute.Schema;
            var result = callback(tableName, schemaName, new GetPropertyExpressions<T>(SharedState_ModelInstanceType));
            Monitor.Exit(_LOCK);
            return result.ToList();
        }
        public static object Insert<TInput>(this IDbConnection connection, TInput entity) where TInput : class
        {
            Monitor.Enter(_LOCK);
            SharedState_ModelInstanceType = entity.GetType();
            return DapperExtensions.DapperExtensions.Insert(connection, entity);
        }
    }
    
    public class GetPropertyExpressions<TInput> : IEnumerable<Expression<Func<TInput, object>>>
    {
        private readonly Type _instanceType;
    
        public GetPropertyExpressions(Type instanceType)
        {
            _instanceType = instanceType;
        }
        public IEnumerator<Expression<Func<TInput, object>>> GetEnumerator()
        {
            return _instanceType
                .GetProperties()
                .Select(p => new GetPropertyExpression<TInput>(_instanceType, p.Name).Content()).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public class GetPropertyExpression<TInput> : IContent<Expression<Func<TInput, object>>>
    {
        private readonly Type _instanceType;
        private readonly string _propertyName;
        public GetPropertyExpression(Type instanceType, string propertyName)
        {
            _instanceType = instanceType;
            _propertyName = propertyName;
        }
        public Expression<Func<TInput, object>> Content()
        {
            // Expression<Func<IDb, object>> :: model => (object)(new DbModel().Title)
    
            var newInstance = Expression.New(_instanceType);
            var parameter = Expression.Parameter(typeof(TInput), "model");
    
            var getPropertyExpression = Expression.Property(newInstance, _propertyName);
            var convertedProperty = Expression.Convert(getPropertyExpression, typeof(object));
            var lambdaExpression = Expression.Lambda(convertedProperty, parameter);
    
            return (Expression<Func<TInput, object>>)lambdaExpression;
        }
    }
