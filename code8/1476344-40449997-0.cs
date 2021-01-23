    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Offenders> offenderList = new List<Offenders>() {
                    new Offenders() { name = "Foo", sev = 3, occ = 3},
                    new Offenders() { name = "Bar", sev = 3, occ = 3},
                    new Offenders() { name = "Foobar", sev = 2, occ = 4}
                };
                var results = offenderList.GroupBy(x => new { x.sev, x.occ }).OrderByDescending(x => x.Key.sev).ThenByDescending(x => x.Key.occ).FirstOrDefault();
                Console.WriteLine(string.Join(",",results.Select(x => x.name).ToArray()));
                Console.ReadLine();
            }
        }
        public class Offenders
        {
            public string name { get; set; }
            public int sev { get; set; }
            public int occ { get; set; }
        }
    }
