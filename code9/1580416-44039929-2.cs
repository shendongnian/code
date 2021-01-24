    public class Person {
    
        //..
    
        public static bool operator == (Person a, Person b)
        {
            if (Object.ReferenceEquals(a,null) && Object.ReferenceEquals(b,null))
                return true;
            if (Object.ReferenceEquals(a,null) || Object.ReferenceEquals(a,null))
                return false;
            return a.LocType == b.LocType && a.ClaType != b.ClaType;
        }
        public static bool operator != (Person a, Person b)
        {
           return ! (a == b);
        }
    
    }
