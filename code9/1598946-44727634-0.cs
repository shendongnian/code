    public class MyReturnType
    {
        public List<Dictionary<string, object>> Status { get; set; }
        public List<Dictionary<string, object>> SomethingElse { get; set; }
    }
    var myReturnType = new MyReturnType
    {
        Status = statusList,
        SomethingElse = someOtherList
    }
    return JsonConvert.SerializeObject(myReturnType, Formatting.Indented);
