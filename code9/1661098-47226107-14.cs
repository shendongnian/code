    interface ISurnameCheckable
    {
        public string String1 {get;}
        public string String2 {get;}
        public double Threshold {get;}
    }
    class Table1 : ISurnameCheckable
    {
        public int Id {get; set;}
        public string Street {get; set;}
        public string City {get; set}
        // implementation of ISurnameCheckable
        public string String1 {get{return this.Street;}}
        public string String2 {get{return this.City;}}
        ...
    }
