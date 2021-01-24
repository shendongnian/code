    public class Thing
    {
        public List<OtherThing> ThisList { get; set; }
        public Thing()
        {
            this.ThisList = new List<OtherThing>();
        }
    }
