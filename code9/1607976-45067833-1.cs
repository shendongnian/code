        public static Expression<Func<T, P>> GetGetter<T, P>(string propName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propName);
            return Expression.Lambda<Func<T, P>>(property, parameter);
        }
        public static Expression<Func<T, P>> GetGetter<T, P>(PropertyInfo propInfo)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propInfo);
            return Expression.Lambda<Func<T, P>>(property, parameter);
        }
