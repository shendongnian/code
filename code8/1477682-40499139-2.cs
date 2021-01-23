    class MyModelComparer : IEqualityComparer<MyModel>
    {
        public bool Equals(MyModel x, MyModel y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
    
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.GridX == y.GridX && x.GridY == y.GridY;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(MyModel model)
        {
            return (model.GridX.GetHashCode()*397)^model.GridY.GetHashCode
        }
    
    }
