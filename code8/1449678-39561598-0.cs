    public class RestaurantContext :DbContext
    {
        public DbSet<TableGroupe> tTableGroupe { set; get; }
        public DbSet<TableCouple> tTableCouple { set; get; }
        public DbSet<Menu> tMenu { set; get; }
        public DbSet<Reservation> tReservation { set; get; }
        public RestaurantContext() : base("RestaurentDB") {
     }
