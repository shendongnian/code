    public static class LoggerManager
    {
        public static void Error()
        {
            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var clasName = methodInfo.ReflectedType.Name;
        }
    }
