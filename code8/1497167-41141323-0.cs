    public static T With<T, P>(this T target, Expression<Func<T, P>> selector, P value)
    {
        var expression = selector.Body as MemberExpression;
        if (expression == null)
        {
            throw new InvalidOperationException();
        }
            
        var name = expression.Member.Name;
        var constructor = typeof(T).GetConstructors().First();
        var args = GetParamaters(target, value, constructor, name);
        return (T)Activator.CreateInstance(typeof(T), args.ToArray());
    }
    private static IEnumerable<object> GetParamaters<T, P>(T target, P value, ConstructorInfo constructor, string name)
    {
        foreach (var parameterInfo in constructor.GetParameters())
        {
            if (parameterInfo.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            {
                yield return value;
            }
            else
            {
                var property =
                    typeof(T).GetProperties()
                        .First(x => x.Name.Equals(parameterInfo.Name, StringComparison.InvariantCultureIgnoreCase));
                yield return property.GetValue(target, null);
            }
        }
    }
