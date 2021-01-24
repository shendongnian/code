    public class Result
    {
        public string apartmentNo { get; set; }
        public string city { get; set; }
        public string floor { get; set; }
        public string houseNo { get; set; }
        public string houseNo2 { get; set; }
        public string phoneNo { get; set; }
        public string postalCode { get; set; }
        public string region { get; set; }
        public string street { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    
    public class RootObject
    {
        public int resultCount { get; set; }
        public List<Result> results { get; set; }
    }
