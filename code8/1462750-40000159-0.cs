    public class RootClass
    {
    	public HotelRoomType hotel_room_types { get; set; }
    }
    public class HotelRoomType
    {
    	
    	public BedModelAndDetails QUEEN { get;set; }
    }
    public class BedModelAndDetails
    {
    	public string accessibility { get; set; }
    	public string room_smoking_policy { get; set; }
    	public string code { get; set; }
    	
    	//public BedType bed_type { get; set; }
    	public object bed_type { get; set; }
    	//public BedType extra_bed_type { get; set; }
    	public object extra_bed_type { get; set; }
    	public List<List<BedConfiguration>> bed_configurations { get; set; }
    	public List<List<BedConfiguration>> extra_bed_configurations { get; set; }
    }
    
    public class BedType
    {
    	public List<int> standard { get; set; } 
    	public List<int> custom { get; set; } 
    }
    public class BedConfiguration
    {
    	public string type { get; set; }
    	public int code { get; set; } 
    	public int count { get; set; } 
    }
        
    [TestMethod]
    public void ReplaceJson()
    {
    	var inputJson1 = "{\"hotel_room_types\": {\"QUEEN\": {\"code\": \"QUEEN\", \"bed_type\": {\"standard\": [5],\"custom\": [] }, \"extra_bed_type\": { \"standard\": [5], \"custom\": [] },\"accessibility\": \"compliant_with_local_laws_for_disabled\", \"room_smoking_policy\": \"non_smoking\" } " +"}}";
    	var input1 = JsonConvert.DeserializeObject<RootClass>(inputJson1, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
    
    	var inputJson2 = "{\"hotel_room_types\": {\"QUEEN\": {\"code\": \"QUEEN\",\"bed_configurations\": [[{\"type\": \"standard\",\"code\": 3,\"count\": 1}],[{\"type\": \"standard\",\"code\": 1,\"count\": 2}]],\"extra_bed_configurations\": [[{\"type\": \"standard\",\"code\": 900302,\"count\": 1},{\"type\": \"custom\",\"name\": \"Rollaway with wheel locks and adjustable height\",\"count\": 1}]],\"accessibility\": \"compliant_with_local_laws_for_disabled\",\"room_smoking_policy\": \"non_smoking\"} }}";
    	var input2 = JsonConvert.DeserializeObject<RootClass>(inputJson2);
    
    	//var finalInput = new RootClass();
    	//finalInput.hotel_room_types = inputJson1
    	//input1.hotel_room_types.QUEEN.bed_configurations = input2.hotel_room_types.QUEEN.bed_configurations;
    	//input1.hotel_room_types.QUEEN.extra_bed_configurations = input2.hotel_room_types.QUEEN.extra_bed_configurations;
    	input1.hotel_room_types.QUEEN.bed_type = input2.hotel_room_types.QUEEN.bed_configurations;
    	input1.hotel_room_types.QUEEN.extra_bed_type = input2.hotel_room_types.QUEEN.extra_bed_configurations;       
    }
