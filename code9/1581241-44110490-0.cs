    using myLocation = mytestApp.Location;
    
    namespace mytestApp
    {
        public class Customer : Location 
        {
            private void myMethod()
            {
                myLocation loc = new myLocation();
                loc.IsCustomer = true;
                loc.IsSupplier = false;
            }
        }
    
        public class Supplier : Location { }
    }
