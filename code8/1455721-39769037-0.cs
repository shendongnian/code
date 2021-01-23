    public class QuestionMetadata
    {
        public PropertyInfo PropInfo { get; set; }
        public Expression<Func<TModel, TValue>> CreateExpression<TModel, TValue>()
        {
            var param = Expression.Parameter(typeof(TModel));
            return Expression.Lambda<Func<TModel, TValue>>(
                Expression.Property(param, PropInfo), param);
        }
    }
    public class TestClass
    {
        public int MyProperty { get; set; }
    }
