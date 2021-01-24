    public class T
            {
                public string A { get; set; }
                public string B { get; set; }
            };
    
            static void Main(string[] args)
            {
                var s1 = Enumerable.Range(0, 1000000).Aggregate(new StringBuilder(), (acc, i) => acc.Append("A")).ToString();
                var s2 = Enumerable.Range(0, 1000000).Aggregate(new StringBuilder(), (acc, i) => acc.Append("B")).ToString();
                var text =$"{s1}|{s2}";
    
                for (int i = 0; i < 5; i++)
                {
                    Stopwatch sw = new Stopwatch();
                    Console.WriteLine("Start");
                    sw.Start();
                    var t1 = CreateT(text);
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    sw.Reset();
    
                    sw.Start();
                    var t2 = CreateLinq(text);
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                    sw.Reset();
                }
                Console.ReadLine();
            }
    
            public static T CreateLinq(string s)
            {
                return s.Aggregate((a: new StringBuilder(), b: new StringBuilder(), c: false),
                    (acc, c) => (a: (!acc.c && c != '|' ? acc.a.Append(c) : acc.a),
                                 b: (acc.c && c != '|' ? acc.b.Append(c) : acc.b),
                                 c: acc.c || c == '|'),
                    acc => new T { A = acc.a.ToString(), B = acc.b.ToString() });
            }
    
            public static T CreateT(string s)
            {
                var split = s.Split('|');
                return new T { A = split[0], B = split[1] };
            }
