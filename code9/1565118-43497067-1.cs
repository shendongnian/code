    static public string GetCommandLineDelimiter<T>(Expression<Func<T>> property)
    {
        if(property != null)
        {
            var memberExpression = (MemberExpression)property.Body;
            string propertyName = memberExpression.Member.Name;
            PropertyInfo prop = typeof(Arguments).GetProperty(propertyName);
            if(prop != null)
            {
                object[] dbFieldAtts = prop.GetCustomAttributes(typeof(ArgumentAttribute), true);
                if(dbFieldAtts.Length > 0)
                {
                    return ((ArgumentAttribute)dbFieldAtts[0]).AssignmentDelimiter;
                }
            }
        }
        return null;
    }
