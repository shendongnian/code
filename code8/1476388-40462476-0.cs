    class TempObject {
        public TempObject(Handlers handlers) {
            handlers.AddHandler<object>(GeneratedClass._staticAction ?? (GeneratedClass._staticAction = GeneratedClass._staticField.Handler));
        }
        [CompilerGenerated]
        [Serializable]
        private sealed class GeneratedClass {
            public static readonly TempObject.GeneratedClass _staticField;
            public static Action<object> _staticAction;
            static GeneratedClass() {
                TempObject.GeneratedClass._staticField = new TempObject.GeneratedClass();
            }
            public GeneratedClass() {
            }
            internal void Handler(object o) {
                Console.WriteLine(o);
            }
        }
    }
