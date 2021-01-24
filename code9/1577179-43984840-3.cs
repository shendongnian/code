    class Program {
        static void Main(string[] args) {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            try {
                throw new Exception("test");
            }
            finally {
                Console.WriteLine("finally");
            }
        }
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine("handle exception");
        }
    }
