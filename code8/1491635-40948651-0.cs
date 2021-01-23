    void Main()
    {
	 var list = new List<myClass>()
	 list.Add(new myClass() {
	 Vocabluary = "Vocabluary ", 
	 Meaning = "meaning", 
	 Number = 1, 
	 Group = 2})
    }
    public class myClass
    {
	 public string Vocabluary { get; set; }
	 public string Meaning { get; set; }
	 public int Number { get; set; }
	 public int Group { get; set; }
    }
