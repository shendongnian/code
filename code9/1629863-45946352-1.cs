    public class test
    {
    	public int id { get; set; }
    	public string name { get; set; }
    	public virtual string lname { get; set; }
    }
    public class test1 : test
    {
      [JsonIgnore]
      public override string lname { get; set; }
    }
    var list = new List<test>()
    {
       new test() {id = 1, name = "name1", lname = "lname1"},
       new test1() {id = 2, name = "name2", lname = "lname2"}
    };
    var s = JsonConvert.SerializeObject(list);
