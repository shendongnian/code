    public static void Main()
	{
        // I use the json direclty instead of the httpClient for the example
        var json = @"[
        {
        ""ID"": 1,
        ""Namn"": ""Conference Microsoft"",
        ""StartDatum"": ""2017-11-15T10:00:00"",
        ""SlutDatum"": ""2017-11-15T12:00:00"",
        ""KonferensID"": null
        },
        {
        ""ID"": 2,
        ""Namn"": ""föreläsning"",
        ""StartDatum"": null,
        ""SlutDatum"": null,
        ""KonferensID"": null
        }
        ]";
        // See the official doc there: https://www.newtonsoft.com/json
		var conferences = JsonConvert.DeserializeObject<List<Conference>>(json);
		Console.WriteLine(conferences[0].StartDatum);
	}
	
    // this class was generated with http://json2csharp.com/
	public class Conference
    {
        public int ID { get; set; }
        public string Namn { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? SlutDatum { get; set; }
        public object KonferensID { get; set; } // we cant know the type here. An int maybe?
    }
