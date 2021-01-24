    public class MyReturnType
    {
        public List<IDictionary<string, object>> Status { get; set; }
        public List<IDictionary<string, object>> SomethingElse { get; set; }
    }
    var myReturnType = new MyReturnType
    {
        Status = statusList,
        SomethingElse = someOtherList
    };
    return JsonConvert.SerializeObject(myReturnType, Formatting.Indented);
