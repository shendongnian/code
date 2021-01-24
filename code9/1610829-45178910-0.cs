    public class Bus
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public string PlateNumber { get; set; }
    }
    
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        [ForeignKey(typeof(Bus))]
        public int BusId { get; set; }
    
        [ManyToOne]
        public Bus Bus { get; set; }
    }
