    public static string getToken(string templateString, ref int i, out bool isToken)
    {
        int j = i;
        if (templateString[j] == '{')
        {
            isToken = true;
            j++;
            int k = templateString.IndexOf('}', j);
            if (k == -1)
            {
                throw new Exception();
            }
            i = k + 1;
            return templateString.Substring(j, k - j);
        }
        else
        {
            isToken = false;
            i++;
            return templateString[j].ToString();
        }
    }
    public static Expression<Func<Account, string>> CreateTemplate(string templateString)
    {
        var formatObjs = new List<Expression>();
        var formatString = new StringBuilder();
        int parameterNumber = 0;
        var accountParameter = Expression.Parameter(typeof(Account), "a");
        for (int i = 0; i < templateString.Length;)
        {
            bool isToken;
            var token = getToken(templateString, ref i, out isToken);
            if (isToken)
            {
                Expression<Func<Account, string>> member;
                switch (token)
                {
                    case "u1:firstname":
                        member = a => a.User1.FirstName;
                        break;
                    case "u1:lastname":
                        member = a => a.User1.LastName;
                        break;
                    // other possible tokens.
                    default: // constant
                        throw new Exception();
                }
                formatObjs.Add(Expression.Invoke(member, accountParameter));
                formatString.Append('{');
                formatString.Append(parameterNumber);
                formatString.Append('}');
                parameterNumber++;
            }
            else
            {
                formatString.Append(token);
            }
        }
        var formatMethod = typeof(string).GetMethod("Format", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(object[]) }, null);
        var formatConstantExpression = Expression.Constant(formatString.ToString());
        var formatObjsExpression = Expression.NewArrayInit(typeof(object), formatObjs);
        var lambdaExpression = Expression.Lambda<Func<Account, string>>(Expression.Call(formatMethod, formatConstantExpression, formatObjsExpression), accountParameter);
        return lambdaExpression;
    }
