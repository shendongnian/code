    public abstract class Query<TBuilder> where TBuilder : IRecordBuilder
    {
      protected TBuilder RecordBuilder;
      public abstract IList<IRecords> GetRecordsFromResults();
    }
    public sealed class ConcreteQuery : Query<RecordsPerMonthBuilder>
    {
        ...
    }
