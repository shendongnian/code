    public class ApiResult
    {
        public ApiResult()
        {
            Results = new List<User>();
        }
        public bool Success { get; set; }
        public List<User> Results { get; set; }
    }
