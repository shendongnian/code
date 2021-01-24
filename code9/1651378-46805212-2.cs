    public class TextWriterProvider : ITextWriterProvider
    {
        public static readonly AsyncLocal<TextWriter> CurrentWriter =
            new AsyncLocal<TextWriter>();
        public TextWriter Current => CurrentWriter.Value;
    }
    // Registration
    container.Register<ITextWriterProvider, TextWriterProvider>(Lifestyle.Singleton);
    // Assign the log to the CurrentWriter at the start of the request
    public Task MyQueueHandler(TextWriter log)
    {
        TextWriterProvider.CurrentWriter = log;
        // execute rest of request
    }
