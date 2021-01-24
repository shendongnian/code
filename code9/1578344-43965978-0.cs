    public class User
    {
        ....
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<Facility> OwnedFacilities { get; set; }
    }
