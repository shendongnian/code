    public class Person {
    
        //..
    
        public static bool operator == (Person a, Person b)
        {
            if (a == null && b == null)
                return true;
            if (a == null || b == null)
                return false;
            return a.LocType == b.LocType && a.ClaType != b.ClaType;
        }
    
    }
