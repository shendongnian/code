    public class ShipmnetContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Pallet> Pallets { get; set; }  
    }
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public ICollection<Destination> ShipmentStops { get; set; }
        public Shipment()
        {
            ShipmentStops = new HashSet<Destination>();
        }
    }
    public class Destination
    {
        [Key]
        public string DestinationId { get; set; }
        public int DestinationOrder { get; set; }
        //[Required]
        public Shipment Shipment { get; set; } //Foreign key to Shipment table, make property NotNull by adding [Required] attribute
        public ICollection<Pallet> Pallets { get; set; }
        public Destination()
        {
            Pallets = new HashSet<Pallet>();
        }
    }
    public class Pallet
    {
        public int PalletId { get; set; }
        public string PalletDescription { get; set; }
        public Destination Destination { get; set; } //Foreign key to Destination table
    }
