        public static Expression<Func<T, P>> GetGetter<T, P>(string propName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.PropertyOrField(parameter, propName);
            return Expression.Lambda<Func<T, P>>(property, parameter);
        }
