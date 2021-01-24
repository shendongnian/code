    public class KriDS : IDatasource
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public int[] Values { get; set; }
        public KriDS()
        {
            Description = "This is a description";
            Name = "Test1";
            Values = new int[] { 1, 5, 7, 6, 7 };
        }
    }
