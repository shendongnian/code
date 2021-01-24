    public interface ISomeOperation
    {
        string DoOperation(string data);
    }
    public class OperationA : ISomeOperation
    {
        public string DoOperation(string data)
        {
            //implemention.  
            return data;
        }
    }
    public class OperationB : ISomeOperation
    {
        public string DoOperation(string data)
        {
            //implemention. 
            return data;
        }
    }
    public class OperationC : ISomeOperation
    {
        public string DoOperation(string data)
        {
            //implemention.  
            return data;
        }
    }
    public class OperationD : ISomeOperation
    {
        public string DoOperation(string data)
        {
            //implemention.  
            return data;
        }
    }
    public class OperationContext
    {
        private readonly Dictionary<string, ISomeOperation> _operationStrategy = new Dictionary<string, ISomeOperation>();
        public OperationContext()
        {
            _operationStrategy.Add("name1", new OperationA());
            _operationStrategy.Add("name2", new OperationB());
            _operationStrategy.Add("name3", new OperationC());
            _operationStrategy.Add("name4", new OperationD());
        }
        public string GetOperationData(string searchType, string data)
        {
            return _operationStrategy[searchType].DoOperation(data);
        }
    }
