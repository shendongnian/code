    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args) {
                var adresses = FilterByAddress("Address", new List<Person> { new Person { Address = "Address1" }, new Person { Address = "AAAAAA" } });
            }
            public static IEnumerable<Person> FilterByAddress(string strToCheck, List<Person> list) {
                var strToCheckParm = Expression.Parameter(typeof(string), "strToCheck");
                var listParam = Expression.Parameter(typeof(IEnumerable<Person>), "list");
                Expression<Func<Person, bool>> contains = a => a.Address.Contains(strToCheck);
                var select = typeof(Enumerable).GetMethods().Single(m => m.Name.Equals("Where") && m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 2);
                var genericMethod = select.MakeGenericMethod(new[] { typeof(Person) });
                var call = Expression.Call(null, genericMethod, new Expression[] { listParam, contains });
                var lambda = Expression.Lambda<Func<IEnumerable<Person>, IEnumerable<Person>>>(call, new[] { listParam });
                return lambda.Compile().Invoke(list);
            }
        }
        public class Person
        {
            public string Address { get; set; }
        }
    }
