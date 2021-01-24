    public class Expresion {
        // We need the anonymous type that we want to use
        private static readonly Type AnonymousType = new { item = 0.0, index = 0 }.GetType();
        public void CreateExpression() {
            //Below is the LINQ expression I want to convert
            Expression<Func<Data, List<int>>> exp2 = p => p.s[new int[] { 14, 5 }].Select((item, index) => new { item, index }).Select(x => x.index).ToList();
            ParameterExpression p1 = Expression.Parameter(typeof(Data), "p");
            MemberExpression s1 = Expression.PropertyOrField(p1, "s");
            // The indexer
            PropertyInfo dictItem = s1.Type.GetProperty("Item");
            // The key to the dictionary, new int[] { 14, 5 }
            var key = Expression.NewArrayInit(typeof(int), Expression.Constant(14), Expression.Constant(5));
            // s[new int[] { 14, 5 }]
            var getItem = Expression.Property(s1, dictItem, key);
            // Enumerable.Select with indexer (generic)
            var enumerableSelectIndexTSourceTResult = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                       where x.Name == "Select" && x.IsGenericMethod
                                                       let args = x.GetGenericArguments()
                                                       where args.Length == 2
                                                       let pars = x.GetParameters()
                                                       where pars.Length == 2 &&
                                                           pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                           pars[1].ParameterType == typeof(Func<,,>).MakeGenericType(args[0], typeof(int), args[1])
                                                       select x).Single();
            // Enumerable.Select with indexer (non-generic)
            var enumerableSelectIndex = enumerableSelectIndexTSourceTResult.MakeGenericMethod(typeof(double), AnonymousType);
            // Inner function start
            ParameterExpression item1 = Expression.Parameter(typeof(double), "item");
            ParameterExpression index1 = Expression.Parameter(typeof(int), "index");
            var innerExpression1 = Expression.Lambda(Expression.New(AnonymousType.GetConstructors().Single(), item1, index1), item1, index1);
            // .Select((item, index) => new { item, index })
            var select1 = Expression.Call(enumerableSelectIndex, getItem, innerExpression1);
            // Inner function end
            // Enumerable.Select without indexer (generic)
            var enumerableSelectTSourceTResult = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                  where x.Name == "Select" && x.IsGenericMethod
                                                  let args = x.GetGenericArguments()
                                                  where args.Length == 2
                                                  let pars = x.GetParameters()
                                                  where pars.Length == 2 &&
                                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                      pars[1].ParameterType == typeof(Func<,>).MakeGenericType(args[0], args[1])
                                                  select x).Single();
            // Enumerable.Select without indexer (non-generic)
            var enumerableSelect = enumerableSelectTSourceTResult.MakeGenericMethod(AnonymousType, typeof(int));
            // Inner function start
            ParameterExpression anonymousType1 = Expression.Parameter(AnonymousType, "x");
            var innerExpression2 = Expression.Lambda(Expression.Property(anonymousType1, "index"), anonymousType1);
            // Inner function end
            // .Select((previous select), x => x.index)
            var select2 = Expression.Call(enumerableSelect, select1, innerExpression2);
            // Enumerable.ToList (generic)
            var enumerableToListTSource = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                           where x.Name == "ToList" && x.IsGenericMethod
                                           let args = x.GetGenericArguments()
                                           where args.Length == 1
                                           let pars = x.GetParameters()
                                           where pars.Length == 1 &&
                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0])
                                           select x).Single();
            // Enumerable.ToList (non-generic)
            var enumerableToList = enumerableToListTSource.MakeGenericMethod(typeof(int));
            // .ToList((previous select))
            var toList1 = Expression.Call(enumerableToList, select2);
            var exp1 = Expression.Lambda<Func<Data, List<int>>>(toList1, p1);
            var func1 = exp1.Compile();
            // Test
            var data = new Data();
            data.S[new int[] { 14, 5 }] = new List<double> { 1.0, 2.0 };
            var result = func1(data);
        }
    }
