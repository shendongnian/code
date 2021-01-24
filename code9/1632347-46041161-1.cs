    class TireCar
    {
        public int Id  { get; set; }
        public int TireId { get; set; }
        public int? CarId { get; set; }
        public int Size { get; set; }
        public virtual TireBrand tire { get; set; }
        public virtual Car car { get; set; }
    }
