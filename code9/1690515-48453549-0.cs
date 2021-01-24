        [HttpGet("/[controller]/test/{searchTerm}")]
        public IActionResult Test(string searchTerm)
        {                     
            var stringSearchProvider = new StringSearchExpressionProvider();
            var cid = 1;
            //turns IQueryable<CategoryDto>
            var q = _service.GetAll();
            //c
            var parameter = Expression.Parameter(typeof(CategoryCultureDto), "c");
            var property = typeof(CategoryCultureDto).GetTypeInfo().DeclaredProperties
                .Single(p => p.Name == "Name");
            //c.Name
            var memberExpression = Expression.Property(parameter, property);
            //searchTerm = Foo
            var constantExpression = Expression.Constant(searchTerm);
            //c.Name.Contains("Foo")
            var containsExpression = stringSearchProvider.GetComparison(
                memberExpression,
                "co",
                constantExpression);
            //cultureExpression = (c.CultureId == cultureId)
            var cultureProperty = typeof(CategoryCultureDto)
                .GetTypeInfo()
                .GetProperty("CultureId");
            //c.CultureId
            var cultureMemberExp = Expression.Property(parameter, cultureProperty);
            //1
            var cultureConstantExp = Expression.Constant(cid, typeof(int));
            //c.CultureId == 1
            var equalsCulture = (Expression) Expression.Equal(cultureMemberExp, cultureConstantExp);
            //(c.CultureId == 1) && (c.Name.Contains("Foo"))
            var bothExp = (Expression) Expression.And(equalsCulture, containsExpression);
            // c => ((c.CultureId == 1) && (c.Name.Contains("Foo"))
            var lambda = Expression.Lambda<Func<CategoryCultureDto, bool>>(bothExp, parameter);
            
            //x
            var categoryParam = Expression.Parameter(typeof(CategoryDto), "x");
            //x.Globals.Any(c => ((c.CultureId == 1) && (c.Name.Contains("Foo")))
            var finalExpression = ProcessListStatement(categoryParam, lambda);
            //x => (x.Globals.Any(c => ((c.CultureId == 1) && (c.Name.Contains("Foo"))))
            var finalLambda = Expression.Lambda<Func<CategoryDto, bool>>(finalExpression, categoryParam);
            var query = q.Where(finalLambda);
            var list = query.ToList();
            return Ok(list);
        }
        public Expression GetMemberExpression(Expression param, string propertyName)
        {
            if (!propertyName.Contains(".")) return Expression.Property(param, propertyName);
            var index = propertyName.IndexOf(".");
            var subParam = Expression.Property(param, propertyName.Substring(0, index));
            return GetMemberExpression(subParam, propertyName.Substring(index + 1));
        }
        private Expression ProcessListStatement(ParameterExpression param, LambdaExpression lambda)
        {
            //you can inject this as a parameter so you can apply this for any other list property
            const string basePropertyName = "Globals";
            //getting IList<>'s generic type which is CategoryCultureDto in this case
            var type = param.Type.GetProperty(basePropertyName).PropertyType.GetGenericArguments()[0];
            //x.Globals
            var member = GetMemberExpression(param, basePropertyName);
            var enumerableType = typeof(Enumerable);
            var anyInfo = enumerableType.GetMethods()
            .First(m => m.Name == "Any" && m.GetParameters().Length == 2);
            anyInfo = anyInfo.MakeGenericMethod(type);
            //x.Globals.Any(c=>((c.Name.Contains("Foo")) && (c.CultureId == cid)))
            return Expression.Call(anyInfo, member, lambda);
        }
