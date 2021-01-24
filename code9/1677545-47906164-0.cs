    class Base
    {
        int Id { get; set; }
        public virtual bool IsDuplicateOf(Base other)
        {
            return other != null && Id == other.Id;
        }
    }
    
    class Derived1 : Base
    {
        string DerivedProperty1 { get; set; }
    
        public override bool IsDuplicateOf(Base other)
        {
            return IsDuplicateOf(other as Derived1);
        }
    
        private bool IsDuplicateOf(Derived1 other)
        {
            return other != null && DerivedProperty1 == other.DerivedProperty1;
        }
    }
    
    class Derived2 : Base
    {
        string DerivedProperty2 { get; set; }
    
        public override bool IsDuplicateOf(Base other)
        {
            return IsDuplicateOf(other as Derived2);
        }
    
        private bool IsDuplicateOf(Derived2 other)
        {
            return other != null && DerivedProperty2 == other.DerivedProperty2;
        }
    }
