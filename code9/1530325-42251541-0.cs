    public class MyObjectComparer : IEqualityComparer<KeyValuePair<string,MyObject>>
    {
       public bool Equals(KeyValuePair<string, MyObject> obj1, KeyValuePair<string, MyObject> obj2)
       {
            if (obj1 == null) return obj2 == null;
            if (obj2 == null) return false;
            if (obj1.Key != obj2.Key) return false;
            
            if (obj1.Value == null) return obj2.Value == null;
            if (obj2.Value == null) return false;
 
            return obj1.Value.myInt == obj2.Value.myInt && 
                   obj1.Value.myString == obj2.Value.myString;
       }
       public int GetHashCode(MyObject obj)
       {
           if (obj == null) return 0;
           int hash = obj.Key.GetHashCode();
           if (obj.Value == null) return hash;
           return hash ^ obj.Value.myInt.GetHashCode() ^ obj.Value.myString.GetHashCode();
       }
    }
