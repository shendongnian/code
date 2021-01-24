    public class baseclass
    {
        public baseclass() : this("google") { }
        public baseclass(string newp1)
        {
           p1 = newp1; // the only place in your code where you init properties
           p2 = "";
        }
    
        public string p1 { get; set; }
        public string p2 { get; set; }
    }
