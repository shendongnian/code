    abstract class ReaderDecorator : MorgReader
    {
        private MorgReader wrappedReader;
        protected ReaderDecorator(MorgReader wrapped)
        {
            wrappedReader = wrapped;
        }
        protected MorgReader WrappedReader
        { get { return wrappedReader; } }
        public override string Read()
        {
            var wrapped = WrappedReader.Read();
            if (!string.IsNullOrEmpty(wrapped))
                wrapped += " ,";
            return wrapped + ReadImpl();
        }
        // template method
        protected abstract string ReadImpl();
    }
