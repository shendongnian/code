    public class Person : Entity, ISoftDelete
    {
        public virtual string Name { get; set; }
    
        public virtual bool IsDeleted { get; set; }
    }
