    public class MyClassList
    {
        public int Id { get; set; }
        public string Amount { get; set; }
    }
    public class ReturnValues
    {
        public int ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
    }
    public class GetMyClassListResult
    {
        public IList<MyClassList> MyClassList { get; set; }
        public ReturnValues ReturnValues { get; set; }
    }
    public class Example
    {
        public GetMyClassListResult GetMyClassListResult { get; set; }
    }
