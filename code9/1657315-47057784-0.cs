    public class Man : ObservableObject  // ToTable Man by default
    {
        public int Id { get; set; } //PK by convention
        public int SonId { get; set; } // FK by convention
        public Son Son { get; set; } 
    }
