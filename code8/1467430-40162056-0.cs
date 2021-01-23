    public static class Extension method
    {
        public static IHtmlContent CustomTextBoxFor<TModel, TResult>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TResult>> expression)
        {
            // very simple implementation, can fail if expression is not as expected!
            var body = expression.Body as MemberExpression;
    
            if(body == null) throw new Exception("Expression refers to a method, not a property");
    
            return helper.TextBoxFor(expression, null, new { id = body.Member.Name, placeholder = helper.DisplayNameFor(expression)  });
        }
    }
