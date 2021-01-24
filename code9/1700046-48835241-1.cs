    public static class Tracer
    {
        public static void log(Expression<Action> action)
        {
            var argumentExtractor = new ArgumentExtractor();
            argumentExtractor.Visit(action);
            var arguments = argumentExtractor.Arguments;
            // to do: write it to log
        }
    }
