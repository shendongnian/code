    public class DataContainer
    {
        public Customer[] records { get; set; }
    }
    var data=JsonConvert.DeserializeObject<DataContainer>(json);
    Debug.Assert(data.records.Length == 3);
