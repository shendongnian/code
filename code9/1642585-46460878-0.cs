    class Program
    {
        private static IDictionary<string, Action> MethodMappings = new Dictionary<string, Action> {
           {"Method1", Method1},
           {"Method2", Method2},
           ...
        }
        public static void Main(string[] args) {
           var methodCall = Console.ReadLine();
           if (!MethodMappings.ContainsKey(methodCall)) {
              //unrecognized command
           }
           MethodMappings[methodCall].Invoke();
        }
 
        private static void Method1() { ... }
        private static void Method2() { ... }
    }
