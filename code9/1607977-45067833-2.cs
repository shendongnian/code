        private class TestCalss
        {
            public int Id { get; set; }
        }
        private static void Main(string[] args)
        {
            var getter = GetGetter<TestCalss, int>(typeof(TestCalss).GetProperty("Id")).Compile();
            Console.WriteLine(getter(new TestCalss { Id = 16 }));
        }
