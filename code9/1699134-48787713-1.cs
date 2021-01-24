        public IEnumerable<T2> GetListOfDifferent<T1, T2>(Func<T1,T2> selector, IEnumerable<T1> inputs)
        {
            var result = inputs.Select(selector).Distinct();
            return result;
        }
        public IEnumerable<T2> GetListOfDifferent<T1, T2>(string propertyName, IEnumerable<T1> inputs)
        {
            var paramExp = Expression.Parameter(typeof(T1), "p1");
            var member = Expression.PropertyOrField(paramExp, propertyName);
            var lamdaExp = Expression.Lambda<Func<T1, T2>>(member, new[] { paramExp });
            var selector = lamdaExp.Compile();
            var result = GetListOfDifferent(selector, inputs);
            return result;
        }
       
