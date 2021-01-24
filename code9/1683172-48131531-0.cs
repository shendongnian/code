    public class GroupMerks
    {
        public string Merk;
        public IEnumerable<Owner> Owners { get; set; }
    }
    public class Owner
    {
        public string Plate { get; set; }
        public string Name { get; set; }
    }
