	public class AgeGroup 
	{
		//Age Group Class 
		[JsonProperty("id")]
		public Guid? Id { get; set; }
		[Jsonproperty("AgeGroup")]
		public string AgeGroupName { get; set; }
		[JsonProperty("App")]
		public List<Appclass> app { get; set; }
				
	}
			
	public class Appclass 
	{
		[JsonProperty("id")]
		public Guid? Id { get; set; }
		[Jsonproperty("AppName")]
		public string AppName { get; set; }
	}
    string yourjsonMethod(List<AgeGroup> ageGroup)
    {
        string json=JsonConvert.SerializeObject(agegroup);
        return json;          
    }
    List<AgeGroup> yourmethod2(string json){
        List<AgeGroup> list=JsonConvert.DeserializeObject<List<AgeGroup>>(json);
        return list;
    }
