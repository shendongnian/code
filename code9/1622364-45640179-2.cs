    public class Test
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public Test CopyWithReference(string reference)
        {
            var copy = (Test)this.MemberwiseClone();
            copy.Reference = reference;
            return copy;
        }
    }
