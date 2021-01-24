        public IEnumerable<string> GetListOfDifferent(Func<Product,string> selector, IEnumerable<Product> products)
        {
            return products.Select(selector).Select(a=> a.ToLower()).Distinct();
        }
        public IEnumerable<string> GetListOfDifferent(string propertyName, IEnumerable<Product> products)
        {
            var parameterExp = Expression.Parameter(typeof(Product), "p1");
            var memberExp = Expression.PropertyOrField(parameterExp, propertyName);
            var lamdaExp = Expression.Lambda(memberExp, new[] { parameterExp });
            var selector = (Func<Product, string>)lamdaExp.Compile();
            return GetListOfDifferent(selector, products);
        }
