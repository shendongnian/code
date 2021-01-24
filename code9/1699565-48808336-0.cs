    var jsonString = currentXRPPrice.Text;
    var deserializedResponse = JsonConvert.DeserializeObject<ReponseType>(jsonString);
    var lastValue = deserializedResponse.Last;
    public class ReponseType
    {
        ...
        public float Last { get; set; }
        ...
    }
