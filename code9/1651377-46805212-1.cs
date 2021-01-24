    public class TextWriterProvider : ITextWriterProvider
    {
        private static readonly AsyncLocal<TextWriter> current =
            new AsyncLocal<TextWriter>();
        public TextWriter Current
        { 
            get => current.Value;
            set => current.Value = value;
        }
    }
    // Registration
    container.Register<ITextWriterProvider, TextWriterProvider>(Lifestyle.Singleton);
    container.Register<TextWriterProvider>(Lifestyle.Singleton);
