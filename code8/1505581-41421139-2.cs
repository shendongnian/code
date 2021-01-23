    public class Activity1
    {
        pubic Activity1()
        {
            this.SomeThings = new List<object>();
        }
        public List<object> SomeThings { get; set; }
    }
    
    public class Activity2
    {
        public Activity2()
        {
            // Now in this clas you can access the item to be shared
            Activity1 act = new Activity1();
            var things = act.SomeThings;
        }
    }
