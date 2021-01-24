    public class MyRepository
    {
        internal List<ReturnData> GetMyDataExample1(RequestData arg) { return new List<ReturnData>(); }
        internal List<ReturnData> GetMyDataExample2(RequestData arg) { return new List<ReturnData>(); }
        internal List<ReturnData> GetMyDataExample3(RequestData arg) { return new List<ReturnData>();  }
    }
    
    public class ReturnData { }
    
    public class Example
    {
        private MyRepository _repo = new MyRepository();
    
        private List<ReturnData> FilterRequestDataAndExecute(RequestData data, Func<RequestData, List<ReturnData>> action)
        {
            // call into another class that may or may not alter RequestData.Payers
            // and then execute the actual code, potentially with some standardized exception management around it
            // or logging or anything else really that would otherwise be repeated
            return action(data);
        }
    
        public List<ReturnData> GetMyDataExample1(RequestData data)
        {
            // call the shared filtering/logging/exception mgmt/whatever code and pass some additional code to execute
            return FilterRequestDataAndExecute(data, _repo.GetMyDataExample1);
        }
    
        public List<ReturnData> GetMyDataExample2(RequestData data)
        {
            // call the shared filtering/logging/exception mgmt/whatever code and pass some additional code to execute
            return FilterRequestDataAndExecute(data, _repo.GetMyDataExample2);
        }
    
        public List<ReturnData> GetMyDataExample3(RequestData data)
        {
            // call the shared filtering/logging/exception mgmt/whatever code and pass some additional code to execute
            return FilterRequestDataAndExecute(data, _repo.GetMyDataExample3);
        }
    }
    
    public class RequestData
    {
        List<string> Payers { get; set; }
    }
