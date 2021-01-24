    public class Meta
    {
        public string status { get; set; }
        public int count { get; set; }
    }
    public class Result
    {
        <Add whatever field you are expecting>
    }
    public class RootObject
    {
        public Meta _meta { get; set; }
        public Result result { get; set; }
    }
