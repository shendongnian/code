    public partial class CarsColors
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Color Color { get; set; }
    }
