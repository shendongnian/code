    public class Father
    {
        //--- Constructor ---
        
        internal Father(FatherState state)
        {
            State = state;
        }
        
        //--- Properties ---
        
        public long Id => State.Id;
        
        public IList<Child> Sons => Children.Where(child => child.Type == ChildType.Son).ToList().AsReadOnly();
        
        public IList<Child> Daughters => Children.Where(child => child.Type == ChildType.Daughter).ToList().AsReadOnly();
        
        //--- Methods ---
        
        public void AddChild(Child child)
        {
            State.Children.Add(child);
        }
        
        public void RemoveChild(Child child)
        {
            State.Children.Remove(child);
        }
    }
    
    internal class FatherState
    {
        [Key]
        public long Id { get; set; }
    
        public virtual ICollection<Child> Children { get; set; }
    }
    
    public class Child
    {
        [Key]
        public long Id { get; set; }
    
        public long FatherId { get; set; }  
    
        public Father Father { get; set; }
        
        public ChildType Type { get; set; }
    }
    
    public enum ChildType
    {
        Son,
        Daughter
    }
