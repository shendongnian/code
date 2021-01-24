    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class DictionaryExtensions
    {
        /// <summary>
        /// This extension method was built for when you want to add a list of items to a dictionary as the values, and you want to use one of those 
        /// items' properties as the key. It uses LINQ to check by property reference. 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="targets"></param>
        /// <param name="propertyToAdd"></param>
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<TValue> targets, Expression<Func<TValue, TKey>> propertyToAdd)
        {
            MemberExpression expr = (MemberExpression)propertyToAdd.Body;
            PropertyInfo prop = (PropertyInfo)expr.Member;
            foreach (var target in targets)
            {
                var value = prop.GetValue(target);
                if (!(value is TKey))
                    throw new Exception("Value type does not match the key type.");//shouldn't happen.
                dict.Add((TKey)value, target);
            }
        }
    }
