    public abstract class Query
    {
        protected IRecordBuilder RecordBuilder { get; private set; }
        protected Query(IRecordBuilder recordBuilder)
        {
            RecordBuilder = recordBuilder;
        }
        public abstract IList<IRecords> GetRecordsFromResults();
    }
