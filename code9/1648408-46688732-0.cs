    public class Staff : ICloneable
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public int Age{get;set;}
        public string Address{get;set;}
    
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
