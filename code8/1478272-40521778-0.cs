    public abstract class MyBaseAbs
    {
        public string CommonProp1 { get; set; }
        public string CommonProp2 { get; set; }
        public string CommonProp3 { get; set; }
    
        public virtual void Save() { }
    }
    public class Mychild1: MyBaseAbs
    {
        public string Mychild1Prop1 { get; set; }
        public string Mychild1Prop2 { get; set; }
        public string Mychild1Prop3 { get; set; }
        public override void Save() { 
            //Implementation for Mychild1
        }
    }
    public class Mychild2: MyBaseAbs
    {
        public string Mychild1Prop1 { get; set; }
        public string Mychild2Prop2 { get; set; }
        public override void Save() { 
            //Implementation for Mychild2
        }
    }
