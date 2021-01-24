    public class ReaderFactory
    {
        public IReader<Result> CreateDefaultResultReader()
        {
            return new DefaultResultReader();
        }
        public IReader<DetailedResult> CreateDetailedResultReader()
        {
            return new DetailedResultReader();
        }
    }
 
