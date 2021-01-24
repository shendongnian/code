    public class Subtype : BaseModel
    {
        public override int Id { get; set; }
        public int? SupplierID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Here is what is expected from EF (two side relation, but you've got only one)
        // public virtual Category Category  { get; set; }
        public virtual Supplier Supplier { get; set; } //<- here 3
    }
