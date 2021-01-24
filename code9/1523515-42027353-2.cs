    public class Base
    {
        public virtual string Key {get; set;}
    }
    
    class ChildA : Base 
    {   
        //This one overrides the default adding extra/different logic
        public override string Key { get; set; } = "Some Value";
    }
    
    class ChildB : Base 
    {   
        //This one adds a new property, making the other one no long accessable directly.
        public new string Key { get; set; } = "Some Value";
    }
    
    var a = new ChildA();
    a.Key //Some Value
    ((Base)a).Key // Some Value
    new ChildB();
    b.Key //Some Value
    ((Base)b).Key // null
