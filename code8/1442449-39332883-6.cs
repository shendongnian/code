    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    namespace LambdaSample.Extensions
    {
        public static class ObjectExtensions
        {
            /// <summary>
            /// Build Filter Dictionary<string,string> used in ExpressionExtensions.BuildPredicate to build
            /// predicates for Predicate Builder based on class's properties values. Filters are then used
            /// by PredicateParser, which converts them to appropriate types (DateTime, int, decimal, etc.)
            /// </summary>
            /// <param name="this">Object to build dictionary from</param>
            /// <param name="includeNullValues">Includes null values in dictionary</param>
            /// <returns>Dictionary with string keys and string values</returns>
            public static Dictionary<string, string> ToFilterDictionary(this object @this, bool includeNullValues)
            {
                var result = new Dictionary<string, string>();
                if (@this == null || !@this.GetType().IsClass)
                    return result;
                // First, generate Dictionary<string, string> from @this by using reflection
                var props = @this.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var value = prop.GetValue(@this);
                    if (value == null && !includeNullValues)
                        continue;
                    // If value already is a dictionary add items from this dictionary
                    var dictValue = value as IDictionary;
                    if (dictValue != null)
                    {
                        foreach (var key in dictValue.Keys)
                        {
                            var valueTemp = dictValue[key];
                            if (valueTemp == null && !includeNullValues)
                                continue;
                            result.Add(key.ToString(), valueTemp != null ? valueTemp.ToString() : null);
                        }
                        continue;
                    }
                    // If property ends with list, check if list of generics
                    if (prop.Name.EndsWith("List", false, CultureInfo.InvariantCulture))
                    {
                        var propName = prop.Name.Remove(prop.Name.Length - 4, 4);
                        var sb = new StringBuilder();
                        var list = value as IEnumerable;
                        if (list != null)
                        {
                            foreach (var item in list)
                            {
                                if (item == null)
                                    continue;
                                if (sb.Length > 0)
                                    sb.Append(",");
                                sb.Append(item.ToString());
                            }
                            result.Add(propName, sb.ToString());
                        }
                        continue;
                    }
                    var str = value != null ? value.ToString() : null;
                    result.Add(prop.Name, str);
                }
                return result;
            }
        }
    }
