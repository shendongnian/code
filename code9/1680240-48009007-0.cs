    public class MyClassA : SomeAbstractClass, ISomeInterface1, ISomeInterface2 {
        public MyClassA(string someData, string checkId) : base(someData) {
            //this property defined in base class
            CheckId = checkId;
        }
    
        internal override string CheckId { get; }
    }
