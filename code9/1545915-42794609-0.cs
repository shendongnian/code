        public static double Sum(double a, double b)
        {
            return a + b;
        }
        public static string SayHello()
        {
            return "Hello";
        }
        static void Main(string[] args)
        {
            MulticastDelegate mydel = new Func<double, double, double>(Sum);
            var ret = mydel.DynamicInvoke(1, 2);
            System.Console.WriteLine(ret);
            mydel = new Func<string>(SayHello);
            ret = mydel.DynamicInvoke();
            System.Console.WriteLine(ret);
            mydel = new Func<string, int, string> ((s, i) => { 
                return $"Would be {s}, {i} times";
             });
            ret = mydel.DynamicInvoke("Hello", 5);
            System.Console.WriteLine(ret);
        }
