    public class RootObject
    {
        public bool isError { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public List<Result> Result { get; set; }
    }
    public class Result
    {
        [JsonConverter(typeof(DisplayValueConverter))]
        public string EmployeeId { get; set; }
        [JsonConverter(typeof(DisplayValueConverter))]
        public string Title { get; set; }
        [JsonConverter(typeof(DisplayValueConverter))]
        public string FirstName { get; set; }
        [JsonConverter(typeof(DisplayValueConverter))]
        public string LastName { get; set; }
    }
