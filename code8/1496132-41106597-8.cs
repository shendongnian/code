    var set = new int[] { 2, 56, -11, 15, 12, 10, 43, -59, -13 };
    var ret = from a in set
              from b in set
              where a != b
              let c = new { a, b }
              group c by Math.Abs(c.a + c.b);
    var minset = ret.First(i => i.Key == ret.Min(j => j.Key))
                    .Select(s=>s);
    Console.WriteLine(minset.Aggregate(new StringBuilder(), 
                                       (sb,v)=>sb.Append(v)
                                                 .AppendLine()
                                      ));
    /*
        { a = -11, b = 12 }
        { a = -11, b = 10 }
        { a = 12, b = -11 }
        { a = 12, b = -13 }
        { a = 10, b = -11 }
        { a = -13, b = 12 }
    */
