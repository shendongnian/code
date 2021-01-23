    public class EmployeeId
        {
            public string DisplayValue { get; set; }
        }
    
        public class Title
        {
            public string DisplayValue { get; set; }
        }
    
        public class FirstName
        {
            public string DisplayValue { get; set; }
        }
    
        public class LastName
        {
            public string DisplayValue { get; set; }
        }
    
        public class Result
        {
            public EmployeeId EmployeeId { get; set; }
            public Title Title { get; set; }
            public FirstName FirstName { get; set; }
            public LastName LastName { get; set; }
        }
    
        public class RootObject
        {
            public bool isError { get; set; }
            public int Status { get; set; }
            public string Message { get; set; }
            public List<Result> Result { get; set; }
        }
