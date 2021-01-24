    void Main()
    {
    	string json = JSONTest();
    	Console.WriteLine(json);
    	var obj = JsonConvert.DeserializeObject<List<Sport>>(json);
    
    	string jsonX2 = JsonConvert.SerializeObject(json);
    	Console.WriteLine(jsonX2);
    	obj = JsonConvert.DeserializeObject<List<Sport>>(jsonX2); // exception
    }
    
    public string JSONTest()
    {
    	List<Sport> sports = new List<Sport>();
    	sports.Add(new Sport() { SportID = 1, SportName = "Tennis" });
    	sports.Add(new Sport() { SportID = 2, SportName = "Footbal" });
    	sports.Add(new Sport() { SportID = 3, SportName = "Swimming" });
    
    	return JsonConvert.SerializeObject(sports);
    }
    
    public class Sport
    {
    	public int SportID { get; set; }
    	public string SportName { get; set; }
    }
