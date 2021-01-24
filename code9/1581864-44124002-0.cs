        static Predicate<object> CreateRegExPredicateSmart(string pattern)
        {
			var regex = new Regex(pattern, RegexOptions.Compiled);
			var paramObject = Expression.Parameter(typeof(object), "p");
			var paramMyType = Expression.TypeAs(paramObject, typeof(MyType));
			var propMyField = Expression.Property(paramMyType, "MyField");
			var constRegex = Expression.Constant(regex);
			var methodInfo = typeof(Regex).GetMethod("IsMatch", new Type[] { typeof(string) });
			var paramsEx = new Expression[] { propMyField };
			var lamdaBody = Expression.Call(constRegex, methodInfo, paramsEx);
            Expression<Func<object, bool>> lamdaSmart = Expression.Lambda<Func<object, bool>>(lamdaBody, paramObject);
            return new Predicate<object>(lamdaSmart.Compile());
        }
