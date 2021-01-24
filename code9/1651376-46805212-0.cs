    // Definition
    public interface ITextWriterProvider // by lack of a better name
    {
        TextWriter Current { get; }
    }
    // Used as dependency of MyLogger
    public MyLogger(ITextWriterProvider logProvider)
    // Implementation visible to your composition root
    public class TextWriterProvider : ITextWriterProvider
    {
        public TextWriter Current { get; set; }
    }
    // Registration
    container.Register<ITextWriterProvider, TextWriterProvider>(Lifestyle.Scoped);
    container.Register<TextWriterProvider>(Lifestyle.Scoped);
    // Wrap the start of the request in a scope and assign the log value to the scope.
    public Task MyQueueHandler(TextWriter log)
    {
        using (AsyncScopedLifestyle.BeginScope(container))
        {
            container.GetInstance<TextWriterProvider>().Current = log;
            // execute rest of request
        }
    }
