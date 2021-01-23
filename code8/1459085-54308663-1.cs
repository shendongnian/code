    public static string Interpolate(this string template, params Expression<Func<object, string>>[] values)
            {
                string result = template;
                values.ToList().ForEach(x =>
                {
                    MemberExpression member = x.Body as MemberExpression;
                    string oldValue = $"{{{member.Member.Name}}}";
                    string newValue = x.Compile().Invoke(null).ToString();
                    result = result.Replace(oldValue, newValue);
                }
    
                    );
                return result;
            }
