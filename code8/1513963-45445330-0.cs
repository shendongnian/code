    public class ExpressionHelper
    {
    
        public static IDictionary<string, object> GetMethodParams<T>(Expression<Func<T, bool>> fromExpression)
        {
            if (fromExpression == null) return null;
    
    
            var body = fromExpression.Body as BinaryExpression;
            if (body == null) return new Dictionary<string, object>();
            var rVal = new Dictionary<string, object>();
    
            var leftLambda = body.Left as BinaryExpression;
            if (leftLambda != null)
            {
                var params1 = GetExpressionParams(leftLambda);
                foreach (var o in params1) rVal.Add(o.Key, o.Value);
            }
            var rightLambda = body.Right as BinaryExpression;
            if (rightLambda != null)
            {
                var params1 = GetExpressionParams(rightLambda);
                foreach (var o in params1) rVal.Add(o.Key, o.Value);
            }
            else
            {
                var params1 = GetExpressionParams(body);
                foreach (var o in params1) rVal.Add(o.Key, o.Value);
            }
    
            return rVal;
        }
    
        /// <summary>
        ///     Get Expression Parameters Recursively
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private static IDictionary<string, object> GetExpressionParams(BinaryExpression body)
        {
            if (body == null) return new Dictionary<string, object>();
    
            var rVal = new Dictionary<string, object>();
    
            var leftLambda = body.Left as BinaryExpression;
            while (leftLambda != null)
            {
                var params1 = GetExpressionParams(leftLambda);
                foreach (var o in params1) if (!rVal.ContainsKey(o.Key)) rVal.Add(o.Key, o.Value);
                leftLambda = body.Left as BinaryExpression;
            }
            var rightLambda = body.Right as BinaryExpression;
            while (rightLambda != null)
            {
                var params1 = GetExpressionParams(rightLambda);
                foreach (var o in params1) if (!rVal.ContainsKey(o.Key)) rVal.Add(o.Key, o.Value);
                rightLambda = body.Right as BinaryExpression;
            }
    
            var rightValue = GetValue(body.Right);
            if (rightValue == null)
            {
                var rightSide = body.Right as ConstantExpression;
                if (rightSide != null) rightValue = rightSide.Value;
            }
    
            var leftSideName = GetMemberName(body.Left);
            if (string.IsNullOrEmpty(leftSideName)) return rVal;
            if (!rVal.ContainsKey(leftSideName)) rVal.Add(leftSideName, rightValue);
    
            return rVal;
        }
    
        /// <summary>
        ///     Get an Equals Expression from the name and value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetEqualExpression<T>(string propertyName, object value)
        {
            var p = Expression.Parameter(typeof(T));
            var property = Expression.Property(p, propertyName);
    
            Expression propertyExpression = Expression.Call(property, property.Type.GetMethod("ToString", Type.EmptyTypes));
    
            var equalsExpression = Expression.Equal(propertyExpression, Expression.Constant(value?.ToString()));
    
            var lambda = Expression.Lambda<Func<T, bool>>(equalsExpression, p);
            return lambda;
        }
    }
