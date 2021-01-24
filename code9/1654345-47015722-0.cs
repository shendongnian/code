    class MyEntity
    {
        public int Id1 {get; set;}
        public int Id2 {get; set;}
        
        public override bool Equals(object obj)
        {
            var other = obj as MyEntity;
            Debug.Assert(other != null, "other != null");
            return other.Id1 == this.Id1 && other.Id2 == this.Id2;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = GetType().GetHashCode();
                hash = (hash * 31) ^ Id1.GetHashCode();
                hash = (hash * 31) ^ Id2.GetHashCode();
                return hash;
            }
        }
    }
    class MyEntityMap: ClassMap<MyEntity> 
    {
        public MyEntityMap() 
        {
             ...
             CompositeId() // I still get the warning, though!
                 .KeyProperty(x => x.Id1)
                 .KeyProperty(x => x.Id2);
             ...
        }
    }
