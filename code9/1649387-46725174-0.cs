    public class Pharmacy  {
       // fields ...
    
       public override bool Equals(object obj) {
           // If parameter is null return false.
            if (obj == null) {
                return false;
            }
    
            // If parameter cannot be cast to Pharmacy return false.
            Pharmacy p = obj as Pharmacy;
            if ((System.Object)p == null) {
                return false;
            }
    
            // Return true if the fields match:
            return p.Lyhenne == this.Lyhenne &&
                   p.PitkaNimi == this.PitkaNimi
                   // && etc...
            ;
       }
    
        public override int GetHashCode() {
            return Lyhenne.GetHashCode() ^ PitkaNimi.GetHashCode() /* ^ etc ... */;
        }
    }
