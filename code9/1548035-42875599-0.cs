    public static TAtt GetAttribute<TAtt,TObj,TProperty>(this Rootobject inst, 
        Expression<Func<TObj,TProperty>> propertyExpression)
             where TAtt : Attribute
          {
             var body = propertyExpression.Body as MemberExpression;
             var expression = body.Member as PropertyInfo;
             var ret = (TAtt)expression.GetCustomAttributes(typeof(TAtt), false).First();
    
             return ret;
          }
