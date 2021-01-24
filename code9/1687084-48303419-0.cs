    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var pairs = new List<Tuple<int, int>>
                {
                    Tuple.Create(1, 2),
                    Tuple.Create(3, 4),
                    Tuple.Create(3, 5),
                    Tuple.Create(5, 6),
                    Tuple.Create(10, 11),
                    Tuple.Create(2, 3),
                };
                var groups = new List<List<int>>();
                foreach (var pair in pairs)
                {
                    var g1 = groups.Select((g, i) => (g, i)).FirstOrDefault(h => h.g.Contains(pair.Item1));
                    var g2 = groups.Select((g, i) => (g, i)).FirstOrDefault(h => h.g.Contains(pair.Item2));
                    if (g1.g == null && g2.g == null)
                    {
                        groups.Add(new List<int>{ pair.Item1, pair.Item2 });
                    }
                    else if (ReferenceEquals(g1.g, g2.g)) // Pair already in a single group.
                    {
                        // Do nothing.
                    }
                    else if (g1.g != null && g2.g != null) // Pair appears in two different groups, so join them.
                    {
                        g1.g.AddRange(g2.g);
                        g1.g = g1.g.Distinct().ToList();
                        groups.RemoveAt(g2.i);
                    }
                    else if (g1.g != null) // First of pair appears in g1, so add second of pair.
                    {
                        g1.g.Add(pair.Item2);
                    }
                    else // Second of pair appears in g2, so add first of pair.
                    {
                        g2.g.Add(pair.Item1);
                    }
                }
                foreach (var group in groups)
                {
                    Console.WriteLine(string.Join(", ", group));
                }
            }
        }
    }
