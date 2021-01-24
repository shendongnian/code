    using System;
    using System.Diagnostics;
    using System.Text;
    namespace NetCoreApp1 {
        class Program {
            static void Main(string[] args) {
                var sync = new object();
                var rnd = new Random();
                Time("method1", () => {
                    var value = $"{rnd.Next(100000000).ToString().PadLeft(8, '0')}{rnd.Next(100000000).ToString().PadLeft(8, '0')}";
                });
                Time("method2", () => {
                    var value = $"{rnd.Next(100000000):D8}{rnd.Next(100000000):D8}";
                });
                Time("next double", () => {
                    var value = rnd.NextDouble().ToString("F16"); // turns out surprisingly slow, even slower than the first two
                });
                Time("method3", () => {
                    var v = new char[16];
                    for (var j = 0; j < 16; j++)
                        v[j] = (char)(rnd.NextDouble() * 10 + 48); // fastest
                    var value = new string(v);
                });
                Time("method3 with lock", () => {
                    lock (sync) {
                        var v = new char[16];
                        for (var j = 0; j < 16; j++)
                            v[j] = (char)(rnd.NextDouble() * 10 + 48); // a tiny bit slower with the lock
                        var value = new string(v);
                    }
                });
                Time("method4", () => {
                    var sb = new StringBuilder(16);
                    for (var j = 0; j < 16; j++)
                        sb.Append((char)(rnd.NextDouble() * 10 + 48)); // slower than method 3
                    var value = sb.ToString();
                });
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
            static void Time(string testName, Action action) {
                var sw = Stopwatch.StartNew();
                for (var i = 0; i < 10000000; i++)
                    action();
                sw.Stop();
                Console.WriteLine($"{testName}: {sw.ElapsedMilliseconds}ms");
            }
        }
    }
