    public abstract class PostalAddressOccupancy
    {
        public DateTime EffectiveDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EntityType { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool IsCorrespondenceAddress { get; set; }
        public PostalAddress PostalAddress { get; set; }
        public string PostalAddressType { get; set; }
        public abstract object GetOccupant();
    }
    public class PostalAddressOccupancy<T> : PostalAddressOccupancy
    {
        public T Occupant { get; set; }
        public override object GetOccupant()
        {
            return Occupant;
        }
    }
    public class PostalAddress
    {
        // Or whatever.  Type was not included in the question.
        public string Address { get; set; }
    }
