    class MyClass
    {
        public int Item1 { get; private set; }
        public int Item2 { get; private set; }
    
        public MyClass(int item1, int item2)=>(Item1,Item2)=(item1,item2); 
    
    
        public override bool Equals(object obj)
        {
            var other = obj as MyClass;
    
            if (other == null)
            {
                return false;
            }
    
            return (this.Item1 == other.Item1 && this.Item2 == other.Item2);
        }
    
        public override int GetHashCode()
        {
    
            return this.Item1;
        }
    }
