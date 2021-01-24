    public class TempObject
    {
    	public string Valueone { get; set; }
    	public string ValueTwo { get; set; }
    	public string ValueThree { get; set; }
    }
    var items = new List<TempObject>();
    var testObjectOne = new TempObject
    {
        Valueone = "test1",
        ValueTwo = "test2",
        ValueThree = "test3"
    };
    items.Add(testObjectOne);
    foreach (var obj in items)
    {
        var val = obj.Valueone;
    }
