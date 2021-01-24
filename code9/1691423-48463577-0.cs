    public class SampleJsonClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShouldSerializeName()
        {
            return (Name != "Tennis");
        }
    }
