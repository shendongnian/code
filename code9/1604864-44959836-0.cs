    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Paging
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
    public class RootObject
    {
        public List<Result> Results { get; set; }
        public Paging Paging { get; set; }
    }
