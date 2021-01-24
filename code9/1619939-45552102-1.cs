    public static class DocumentExtensions
    {
        private static readonly PropertyInfo _piFieldId = (PropertyInfo)((MemberExpression)((Expression<Func<DocumentField, int>>)(f => f.Id)).Body).Member;
        private static Expression<Func<DocumentField, bool>> FieldPredicate<T>(int fieldId, T value, Expression<Func<DocumentField, T>> fieldAccessor)
        {
            var pField = fieldAccessor.Parameters[0];
            var xEqualId = Expression.Equal(Expression.Property(pField, _piFieldId), Expression.Constant(fieldId));
            var xEqualValue = Expression.Equal(fieldAccessor.Body, Expression.Constant(value, typeof(T)));
            return Expression.Lambda<Func<DocumentField, bool>>(Expression.AndAlso(xEqualId, xEqualValue), pField);
        }
        /// <summary>
        /// f => f.<see cref="DocumentField.Id"/> == <paramref name="fieldId"/> && f.<see cref="DocumentField.StringValue"/> == <paramref name="value"/>.
        /// </summary>
        public static Expression<Func<DocumentField, bool>> FieldPredicate(int fieldId, string value) => FieldPredicate(fieldId, value, f => f.StringValue);
        /// <summary>
        /// f => f.<see cref="DocumentField.Id"/> == <paramref name="fieldId"/> && f.<see cref="DocumentField.FloatValue"/> == <paramref name="value"/>.
        /// </summary>
        public static Expression<Func<DocumentField, bool>> FieldPredicate(int fieldId, float? value) => FieldPredicate(fieldId, value, f => f.FloatValue);
        // more overloads here
    }
