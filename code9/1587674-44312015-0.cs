    Warehouse {
        public Guid ID {get;set;}
        public string Name {get;set;}
        public ICollection<WarehouseCustom> CustomersNotes {get; set;}
    }
    Customer { 
        public Guid ID {get;set;}
        public string Name {get;set;}
        
        public ICollection<WarehouseCustom> WarehouseNotes {get; set;}
    }
    WarehouseCustom {
        public Guid ID {get;set;}
        public string Note {get;set;}  //customer specific data
        public virtual Warehouse {get; set;}
        public virtual Customer {get; set;}
    }
