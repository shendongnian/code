    class TempObject {
        public TempObject(Handlers handlers) {
            handlers.AddHandler<object>(Handler);
        }
        private static void Handler(object arg) {
            Console.WriteLine(arg);
        }
    }
