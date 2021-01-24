    class CustomKey
    {
        public CustomKey(params string[] value)
        {
            Values = new List<string>();
            Values.AddRange(value);
        }
        private List<string> Values { get; set; }
        
        // this method run throughout all property configured to create the expressions
        public void ForEachProperty<TSource, TKey>(Action<Expression<Func<TSource, TKey>>, bool> method)
        {
            bool firstItem = true;
            Values.ForEach(f =>
            {
                var expression = CreateExpression<TSource, TKey>(f);
                method(expression, firstItem);
                firstItem = false;
            });
        }
        
        // this method is responsable to create each expression
        Expression<Func<TSource, TKey>> CreateExpression<TSource, TKey>(string property)
        {
            var parameter = Expression.Parameter(typeof(TSource), "x");
            var member = typeof(TSource).GetMember(property).FirstOrDefault();
            Expression body = Expression.MakeMemberAccess(parameter, member);            
            return Expression.Lambda<Func<TSource, TKey>>(Expression.Convert(body, typeof(object)), parameter);
        }
    }
