    public interface IRecord 
    {
    }
    
    public class RecordA : IRecord
    {    
    }
    
    public class RecordB : IRecord
    {
    }
    
    public class RecordCollection<T> : List<IRecord>  where T : IRecord
    {
        public RecordCollection(List<T> records)
        {
        }
    }
