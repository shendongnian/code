    public class MyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationID { get; set; }
        public List<MyFeature> Features { get; set; }
    }
    public class MyFeature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ProductId { get; set; }
        public bool? Selected { get; set; }
    }
