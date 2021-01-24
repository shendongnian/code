    public class Car
    {
        //snip
        [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Door Door { get; set; }
    }
