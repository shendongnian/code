     public partial class TruckType
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public TruckType()
            {
                this.Requests = new HashSet<Request>();
                this.Trucks = new HashSet<Truck>();
            }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int MaxCapacity { get; set; }
        public string ImagePath { get; set; }
        public double LPriceKM { get; set; }
        public double MPriceKM { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Requests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Truck> Trucks { get; set; }
        public virtual User User { get; set; }
    }
