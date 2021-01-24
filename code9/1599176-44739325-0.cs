    public class Test
    {
        public static void someMethod()
        {
            var parameter = Expression.Parameter(typeof(SomeType));
            var predicate = Expression.Lambda<Func<SomeType, bool>>(Combine(
                                "=",
                                Expression.Parameter(typeof(int), GetMemberName((SomeType c) => c.ID)),
                                Expression.Constant(150497)
                            ), parameter);
        }
        public static BinaryExpression Combine(string op, Expression left, Expression right)
        {
            switch (op)
            {
                case "=":
                    return Expression.Equal(left, right);
                case "<":
                    return Expression.LessThan(left, right);
                case ">":
                    return Expression.GreaterThan(left, right);
            }
            return null;
        }
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
    }
    public class SomeType
    {
        public int ID { get; set; }
        private string aString;
    }
