    class MainClass {
        public static void Main(string[] args) {
            var t1 = Task.Run(async () => Console.WriteLine(await Bar("Foo1")));
            var t2 = Task.Run(async () => Console.WriteLine(await Bar("Foo2")));
            Task.WaitAll(t1, t2);
        }
        public static async Task<object> Bar(string name) {
            Task t = (Task)typeof(MainClass).GetMethod(name).Invoke(null, new object[] { "bar" });
            await t.ConfigureAwait(false);
            return (object)((dynamic)t).Result;
        }
        public static Task<string> Foo1(string s) {
            return Task.FromResult("hello");
        }
        public static Task<bool> Foo2(string s) {
            return Task.FromResult(true);
        }
    }
