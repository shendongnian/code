    public string[] GetPropNames<T1, T2>(Expression<Func<T1, T2>> expression)
    {
        var newExp = expression.Body as NewExpression;
        if (newExp == null)
        {
            throw new ArgumentException();
        }
    
        var props = new List<string>(newExp.Arguments.Count);
        foreach (var argExp in newExp.Arguments)
        {
            var memberExp = argExp as MemberExpression;
            if (memberExp == null)
            {
                throw new ArgumentException();
            }
            props.Add(memberExp.Member.Name);
        }
        return props.ToArray();
    }
