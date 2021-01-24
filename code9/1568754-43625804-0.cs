    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        //[Key] attribute is not needed, because of name convention
        public virtual TKey Id { get; set; }
    }
    
    public class X : BaseEntity<Guid>//where TKey(Guid) is PK of A class
    {
        [ForeignKey("a")]
        public override Guid Id { get; set; }
        public virtual A a { get; set; }
    }
