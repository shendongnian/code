       public static P MapObject<T, P>(T from, P to)
            {
                var p = Activator.CreateInstance(typeof (P));
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    typeof(P)
                        .GetProperty( propertyInfo.Name,
                            BindingFlags.IgnoreCase |
                            BindingFlags.Instance |
                            BindingFlags.Public)
                        .SetValue(to,
                            propertyInfo.GetValue(from));
                }
                return to;
            }
