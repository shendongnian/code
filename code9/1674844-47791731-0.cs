    public class Var
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    
    public class SampleJson
    {
        public List<Var> vars { get; set; }
        public List<string> OtherNames { get; set; }
    }
    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
    var sampleJson = jsSerializer.Deserialize<SampleJson>(jsonText);
