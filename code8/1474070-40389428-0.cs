    public class CarVM
    {
        public ICollection<Maintenance> Maintenances { get; set; }
        [Required]
        public string Brand { get; set; }
        // a bunch of other string properties related to a car...
    }
