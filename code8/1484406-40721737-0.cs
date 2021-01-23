    public class Logger {
        // use thread local variable - will have separate instance per thread
        private static readonly ThreadLocal<Logger> _instance = new ThreadLocal<Logger>(() => new Logger());
        // scopes stack
        private readonly Stack<string> _scopes = new Stack<string>();
        public static void BeginScope(string scopeName) {
            // push new scope to the stack
            _instance.Value._scopes.Push(scopeName);
        }
        public static void Log(string message) {
            // use scope from the top of the stack (first check if not null)
            Console.WriteLine(string.Concat(_instance.Value._scopes.Peek(), message));
        }
  
        public static void EndScope() {
            // remove scope from the top
            _instance.Value._scopes.Pop();
        }
    }
