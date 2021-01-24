    class GeometryModel<TAttributes>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //More fields...
    
        public virtual TAttributes Attributes { get; set; }
    }
