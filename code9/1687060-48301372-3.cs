    [HttpPost]
    public void PassThings(List<Thing> objectArray )
    {
        
    }
    
    public class Thing
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
