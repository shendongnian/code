    namespace BoundPropertiesinQuery
    {
        static class IEnumerableExtensions
        {
            class ProjectedVisitor : ExpressionVisitor
            {
                public IList<string> ProjectedPropertyNames { get; set; } = new List<string>();
    
                protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
                {
                    ProjectedPropertyNames.Add(node.Member.Name);
                    return base.VisitMemberAssignment(node);
                }
            }
    
            public static IEnumerable<string> ProjectedProperties<T>(this IQueryable<T> @this)
            {
                var pv = new ProjectedVisitor();
                pv.Visit(@this.Expression);
                return pv.ProjectedPropertyNames.Distinct();
            }
        }
    
        internal class MyObject
        {
            public int Property1 { get; set; }
            public int Property2 { get; set; }
    
            public int Property3 { get; set; }
    
            public int Property4 { get; set; }
        }
    
        internal class MyOtherObject
        {
            public int other1 { get; set; }
    
            public int other2 { get; set; }
    
            public int other3 { get; set; }
    
            public int other4 { get; set; }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var listOfItems = new List<MyOtherObject>()
                {
                    new MyOtherObject
                    {
                        other1 = 1,
                        other2 = 2,
                        other3 = 3,
                        other4 = 4
                    },
                    new MyOtherObject
                    {
                        other1 = 5,
                        other2 = 6,
                        other3 = 7,
                        other4 = 8
                    }
                };
    
               var result = listOfItems.AsQueryable().Select(m => new MyObject
                   {
                       Property1 = m.other1,
                       Property2 = m.other2
                   }).ProjectedProperties();
    
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
    
                Console.ReadLine();
            }
        }
    }
