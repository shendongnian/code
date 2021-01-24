    public class MyModel
    {
        public bool IsNewlyEnrolled { get; set; }
    }
    public HttpResponseMessage MyEndpoint(MyModel model) {
        // true == checked
        // false == unchecked
    }
