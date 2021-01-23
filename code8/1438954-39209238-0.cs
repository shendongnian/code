    public static class Helper
    {
        public static Func<object, object> CreatePropertyGetter(Type type, string propertyName)
        {
            var fieldInfo = type.GetProperty(propertyName);
            var targetExp = Expression.Parameter(typeof(object), "target");
            var fieldExp = Expression.Property(Expression.ConvertChecked(targetExp, type), fieldInfo);
            var getter = Expression.Lambda<Func<object, object>>(fieldExp,targetExp).Compile();
            return getter;
        }
    }
