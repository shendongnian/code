    enum Day {
        [MyAttr(Rate=1.5f)]
        Sunday, 
        [MyAttr(Rate=2)]
        Monday
    }
    public class MyAttr : Attribute {
        public float Rate {get;set;}
    }
