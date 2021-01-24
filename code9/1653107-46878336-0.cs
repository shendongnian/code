    public class FieldAccessor
    {
        private delegate object FieldGetter(object instance);       
        private FieldGetter getter;
        public FieldAccessor(FieldInfo field)
        {
            ParameterExpression instanceParameter = Expression.Parameter(typeof(object), "instance");
            MemberExpression member = Expression.Field(
                field.IsStatic ? null : Expression.Convert(instanceParameter, DeclaringType), // (TInstance)instance
                field);
            LambdaExpression lambda = Expression.Lambda<FieldGetter>(
                Expression.Convert(member, typeof(object)), // object return type
                instanceParameter); // instance (object)
            getter = (FieldGetter)lambda.Compile();
        }
        public object Get(object instance)
        {
            return getter(instance);
        }
    }
