        // A list of delegates that accept an integer and return a string
        private static List<Func<int, string>> delegateList = new List<Func<int, string>>();
        public static string Foo(int x)
        {
            return $"Foo {x}";
        }
        public static void Test()
        {
            delegateList.Add(Foo); // Add a delegate to a named method
            delegateList.Add(delegate(int x) { return $"Bar {x * 2}"; } ); // Add a delegate to an anonymous method
            delegateList.Add(x => $"Baz {x * 3}"); // Add a delegate to a lambda
            foreach (var del in delegateList)
            {
                Console.WriteLine(del(23));
            }
        }
