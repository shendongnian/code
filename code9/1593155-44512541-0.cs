    public class Org : BaseEntity, IEntityBase
    {
        public string Name { get; set; }
        public List <Portfolio> Portfolios  { get; set; } //Note, the naming should be plural, to indicate one to many
    }
