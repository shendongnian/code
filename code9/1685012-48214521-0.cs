    public class MyFactory: ITraceOutputFactory
    {
        public TextWriter Create(string outFile)
        {
            return TextWriter.Null;
        }
    }
