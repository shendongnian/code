    public class C {
        //  x is passed by value. It is the value of a reference. Seriously, it is. 
        public C(List<String> x) {
            List = x;
        }
        public List<String> List { get; set; }
    }
...
    var list = new List<String>();
    var x = new C(list);
    var y = new C(list);
