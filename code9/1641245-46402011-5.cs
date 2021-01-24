        static void Main(string[] args) {
            var strToCheck = "Address";
            var list = new List<Person> { new Person { Address = "Address1" }, new Person { Address = "AAAAAA" } };
            var adresses = FilterByAddress(list, p => p.Address.Contains(strToCheck));
        }
        public static IEnumerable<Person> FilterByAddress(List<Person> list, Expression<Func<Person, bool>> predicateEx) {
            var listParam = Expression.Parameter(typeof(IEnumerable<Person>), "list");
            var select = typeof(Enumerable).GetMethods().Single(m => m.Name.Equals("Where") && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);
            var genericMethod = select.MakeGenericMethod(new[] { typeof(Person) });
            var call = Expression.Call(null, genericMethod, new Expression[] { listParam, predicateEx });
            var lambda = Expression.Lambda<Func<IEnumerable<Person>, IEnumerable<Person>>>(call, new[] { listParam });
            return lambda.Compile().Invoke(list);
        }
