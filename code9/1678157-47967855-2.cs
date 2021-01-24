    public static class Messages {
        // Lazy - search of app domain will be performed only on first call
        private static readonly Lazy<IMessages> _messages = new Lazy<IMessages>(FindMessagesType, true);
        private static IMessages FindMessagesType() {
            // search all types in current app domain
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach (var type in asm.GetTypes()) {
                    if (type.GetInterfaces().Any(c => c == typeof(IMessages))) {
                        return (IMessages) Activator.CreateInstance(type);
                    }
                }
            }
            throw new Exception("No implementations of IMessages interface were found");
        }
        // proxy to found instance
        public static string CodeNotFound => _messages.Value.CodeNotFound;
    }
