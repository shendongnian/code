    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestLinq
    {
        public class A : IComparable, IEquatable<A>
        {
            public string Name { get; set; }
            public double K { get; set; }
    
            public override int GetHashCode()
            {
                return K.GetHashCode();
            }
    
            public int CompareTo(object obj)
            {
                A other = (A)obj;
    
                if (this.K > other.K)
                    return 1;
                if (this.K < other.K)
                    return -1;
    
                return 0;
            }
    
            public bool Equals(A other)
            {
                return this.K == other.K;
            }
        }
    
        class Program
        {
            static public List<T> IntersectAll<T>(IEnumerable<IEnumerable<T>> lists)
            {
                HashSet<T> hashSet = new HashSet<T>(lists.First());
                foreach (var list in lists.Skip(1))
                {
                    hashSet.IntersectWith(list);
                }
    
                return hashSet.ToList();
            }
    
            static void Main(string[] args)
            {
                Dictionary<DateTime, List<A>> dict = new Dictionary<DateTime, List<A>> {
                    { DateTime.Now, new List<A> {
                        new A { Name = "1", K = 20 }, new A {  Name = "1", K = 25 }, new A { Name = "1", K = 27 }, new A {  Name = "1", K= 30 } } },
                    { DateTime.Now.AddDays(1),  new List<A> {
                        new A {  Name = "2",K = 20 }, new A { Name = "2", K = 25 }, new A { Name = "2", K = 27 }, new A { Name = "2", K = 28 } } },
                    { DateTime.Now.AddDays(2), new List<A> {
                        new A { Name = "3", K = 20 }, new A {  Name = "3",K = 21 }, new A { Name = "3", K = 22 },
                        new A { Name = "3", K = 23 }, new A {  Name = "3",K = 24 },
                        new A { Name = "3", K= 25 }, new A { Name = "3",K=  26 }, new A {  Name = "3",K=27 },
                        new A { Name = "3", K= 28 }, new A { Name = "3", K=29 }, new A { Name = "3", K =30 } }
                    }};
    
    #if true
                var intersectedList = dict.Values.Skip(1)
                    .Aggregate(
                        new HashSet<A>(dict.Values.First()),
                        (h, e) => { h.IntersectWith(e); return h; }
                    );
    #else
                var intersectList = IntersectAll( dict.Values);
    #endif
                Console.ReadLine();
            }
        }
    }
