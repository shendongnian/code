    public class PriceList
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime ImportDateTime { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as PriceList;
            return Id == other?.Id;
        }
        
        public override int GetHashCode()
        {
            return Id;
        }
    }
