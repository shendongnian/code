        static void Main(string[] args) {
            var strToCheck = "Address";
            Func<Person, bool> predicate = p => {
                return p.Address.Contains(strToCheck);
            };
            var list = new List<Person> { new Person { Address = "Address1" }, new Person { Address = "AAAAAA" } };
            var adresses = FilterBy<Person>(list, predicate);
        }
        public static IEnumerable<T> FilterBy<T>(List<T> list, Func<T, bool> predicate) {
            var listParam = Expression.Parameter(typeof(IEnumerable<T>), "list");
            Expression<Func<T, bool>> predicateEx = p => predicate(p);
            var select = typeof(Enumerable).GetMethods().Single(m => m.Name.Equals("Where") && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);
            var genericMethod = select.MakeGenericMethod(new[] { typeof(T) });
            var call = Expression.Call(null, genericMethod, new Expression[] { listParam, predicateEx });
            var lambda = Expression.Lambda<Func<IEnumerable<T>, IEnumerable<T>>>(call, new[] { listParam });
            return lambda.Compile().Invoke(list);
        }
    }
