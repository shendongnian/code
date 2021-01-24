    public void addToObject()
    {
        List<Vars> variable = new List<Vars>();
        variable.Add(new Vars { id = "var1", name = { "n1", "n2", "n3", "n4" } });
    }
    public class Vars
    {
        public string id { get; set; }
        public List<string> name { get; set; }
    }
