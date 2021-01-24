    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    namespace ConsoleApplication9
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Relationship r = new Class1().GetRelationShip(s => s.RelationShipProperty);
                Console.WriteLine(r.Name);
                System.Console.ReadLine();
            }
        }
        public static class MyExtention
        {
            public static Relationship GetRelationShip<T, TProperty>(this T t, Expression<Func<T, TProperty>> expression)
            {
                return new Relationship(((expression.Body as MemberExpression).Member as PropertyInfo)
                        .GetCustomAttributes(typeof(RelationshipAttribute))
                        .Select(a=>(RelationshipAttribute)a)
                        .First().Name
                        );
            }
        }
        public class RelationshipAttribute : System.Attribute
        {
            public string Name { get; set; }
            public RelationshipAttribute(string name)
            {
                Name = name;
            }
        }
        public class Relationship
        {
            public string Name { get; set; }
            public Relationship(string name)
            {
                Name = name;
            }
        }
        public class Class1
        {
            [Relationship("RelationShipA")]
            public List<int> RelationShipProperty { get; set; }
        }
    }
