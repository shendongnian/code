    public class ProductGroup : BaseEntity
    {        
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual UoM UoM { get; set; }
        // this cannot be null
        public virtual CustomProductType Type { get; set; }
    }
