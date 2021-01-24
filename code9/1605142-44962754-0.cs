    class CustomComparer<object> : IEqualityComparer<object>
    {
       public bool Equals(object a, object b)
       {
           var personObjectA = a as Person;
           var personObjectB = b as Person;
           return (personObjectA == null && personObjectB == null) ||
                  ((personObjectA.field1 == personObjectB.field1) && ....);      
       }
        
       public int GetHashCode(object a)
       {
          var personObjectA = a as Person;
          return (personObjectA.field1?.GetHashCode() ^ personObjectA.field2?.GetHashCode() ^ ....);
       }
    } 
