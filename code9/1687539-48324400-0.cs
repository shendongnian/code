    class Company
    {
        public int Id {get; set;}
        // every company has zero or more InstalledBases:
        public virtual ICollection<InstalledBase> InstalledBases {get; set;}
    }
    class InstalledBase
    {
        public int Id {get; set;}
        // every InstalledBase belongs to exactly one Company using foreign key:
        public int CompanId {get; set;}
        public virtual Company Company {get; set;}
        // every InstalledBase has zero or more Orders:
        public virtual ICollection<Order> Orders {get; set;}
    }
    class Order
    {
        public int Id {get; set;}
        // every Order belongs to exactly one InstalledBase using foreign key:
        public int InstalledBaseId{get; set;}
        public virtual InstalledBase InstalledBase {get; set;}
    }
