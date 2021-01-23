    public class FieldData
    {
        public int Field1 {get; set;}
        public string Field2 {get; set;}
        public bool Field3 {get; set;}
    }
    JsonConvert.DeserializeObject<List<FieldData>>(jsonString);
