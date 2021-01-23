    public DomainCar //domain class used in my business layers
    {
        public int Id{get;set;}
        public string Name{get;set;}
    }
    public DbCar //Car class to be used in the persistence layer
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public DateTime CreatedDate{get;set;}
        public string CreatedBy{get;set;}
    }
