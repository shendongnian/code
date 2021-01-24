    public class Root
    {
        public ModelState ModelState { get; set; }
    }
    public class ModelState
    {
        [JsonProperty("obj.SystematicDate")]//You should specify the obj. properties here
        public Obj SystematicDate { get; set; }
        [JsonProperty("obj.CustomerId")]
        public Obj CustomerId { get; set; }
        [JsonProperty("obj.userId")]
        public Obj UserId { get; set; }
    }
    public class ObjError
    {
        public string k__BackingField { get; set; }
        public string k__BackingField2 { get; set; }
    }
    public class Obj
    {
        public List<ObjError> _errors { get; set; }
        public string state { get; set; }
    }
