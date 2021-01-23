    public static class Extensions
    {
        // checks if a property equals something, generic way
        public static bool IsEqualTo<T, TValue>(this T source, Expression<Func<T, TValue>> expression,
            Predicate<TValue> predicate)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            if (predicate == null) throw new ArgumentNullException("predicate");
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentOutOfRangeException("expression");
            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentOutOfRangeException("expression");
            var value = propertyInfo.GetValue(source);
            var value1 = (TValue) value;
            var b = predicate(value1);
            return b;
        }
    }
    internal class Demo
    {
        private static void Test()
        {
            var data = new MyData();
            var b1 = data.IsEqualTo(s => s.Valid, t => t == false);
            var b2 = data.IsEqualTo(s => s.Number, t => t == 1234);
        }
        private struct MyData
        {
            public bool Valid { get; set; }
            public int Number { get; set; }
        }
    }
