    using System.Linq;
    using static System.Console;
    
    class Program {
        static void Main(string[] args) {
            var inputs = new[] { "A", "B", "C" };
            var outputs = new[] { "1", "2", "3", "4" };
    
            var res = from i1 in inputs
                      from i2 in inputs
                      where i1 != i2
                      from o1 in outputs
                      from o2 in outputs
                      where o1 != o2
                      let c1 = i1 + o1
                      let c2 = i2 + o2
                      // Avoid {x,y} and {y,x} in result.
                      where c1.CompareTo(c2) < 0
                      select (first: c1, second: c2);
    
            foreach (var r in res) {
                WriteLine($"{{{r.first}, {r.second}}}");
            }
        }
    }
