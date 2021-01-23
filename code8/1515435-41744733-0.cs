    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace Fwd.Repository.EF.Utils
    {
        public static class LinqUtils
        {
            /// <summary>
            ///     Wheres the like.
            /// </summary>
            /// <typeparam name="TSource">The type of the source.</typeparam>
            /// <param name="source">The source.</param>
            /// <param name="valueSelector">The value selector.</param>
            /// <param name="value">The value.</param>
            /// <param name="wildcard">The wildcard.</param>
            /// <returns></returns>
            public static IQueryable<TSource> WhereLike<TSource>(this IQueryable<TSource> source,
                Expression<Func<TSource, string>> valueSelector, string value, char wildcard)
            {
                return source.Where(BuildLikeExpression(valueSelector, value, wildcard));
            }
    
            /// <summary>
            ///     Builds the like expression.
            /// </summary>
            /// <typeparam name="TElement">The type of the element.</typeparam>
            /// <param name="valueSelector">The value selector.</param>
            /// <param name="value">The value.</param>
            /// <param name="wildcard">The wildcard.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentNullException">valueSelector</exception>
            public static Expression<Func<TElement, bool>> BuildLikeExpression<TElement>(
                Expression<Func<TElement, string>> valueSelector, string value, char wildcard)
            {
                if (valueSelector == null)
                    throw new ArgumentNullException("valueSelector");
    
                var method = GetLikeMethod(value, wildcard);
    
                value = value.Trim(wildcard);
                var body = Expression.Call(valueSelector.Body, method, Expression.Constant(value));
    
                var parameter = valueSelector.Parameters.Single();
                return Expression.Lambda<Func<TElement, bool>>(body, parameter);
            }
    
            /// <summary>
            ///     Gets the like method.
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="wildcard">The wildcard.</param>
            /// <returns></returns>
            private static MethodInfo GetLikeMethod(string value, char wildcard)
            {
                var methodName = "Contains";
    
                var textLength = value.Length;
                value = value.TrimEnd(wildcard);
                if (textLength > value.Length)
                {
                    methodName = "StartsWith";
                    textLength = value.Length;
                }
    
                value = value.TrimStart(wildcard);
                if (textLength > value.Length)
                {
                    methodName = (methodName == "StartsWith") ? "Contains" : "EndsWith";
                    textLength = value.Length;
                }
    
                var stringType = typeof(string);
                return stringType.GetMethod(methodName, new Type[] { stringType });
            }
        }
    }
