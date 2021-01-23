    public class Car : VBase 
    {
        // Method 1: define constructor.
        public class Car(VBase v) {
            this.Type = v.Type;
            this.Colour = v.Colour;
        }
        // Method 2: static method.
        public static Car FromVBase(VBase v){
            return new Car()
            {
                this.Type = v.Type;
                this.Colour = v.Colour;        
            };
        }
        public string Name {get;set;}
        public int Year {get;set;}
    }
