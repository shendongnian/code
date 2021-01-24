    public void addToObject()
    {    
        List<Vars> variable = new List<Vars>();
        variable.Add(new Vars { Id = "var1", Names = { "n1", "n2", "n3", "n4" } });
    }
    public class Vars
    {
        public string Id { get; set; }
        public List<string> Names { get; set; }
    }
