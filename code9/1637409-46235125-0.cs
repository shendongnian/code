    public interface IReader<T> where T : Result
    {
        IEnumerable<T> ReadResults();
    }
    public class Result
    {
    }
    public class DetailedResult : Result
    {
        // ... ...
    }
    public class DefaultResultReader : IReader<Result>
    {
        public IEnumerable<Result> ReadResults()
        {
            return null;
        }
    }
    public class DetailedResultReader : IReader<DetailedResult>
    {
        public IEnumerable<DetailedResult> ReadResults()
        {
            return null;
        }
    }
    public abstract class ResultReaderAbsractFactory
    {
        public abstract IReader<Result> CreareDefaultResultReader();
        public abstract IReader<DetailedResult> CreareDetailedResultReader();
    }
    public class ConcreteResultRaderFactory : ResultReaderAbsractFactory
    {
        public override IReader<Result> CreareDefaultResultReader()
        {
            return new DefaultResultReader();
        }
        public override IReader<DetailedResult> CreareDetailedResultReader()
        {
            return new DetailedResultReader();
        }
    }
