    [JsonConverter(typeof(MyViewModelConverter))]
    public class MyViewModel {
        [JsonProperty("images")]
        public ImagesViewModel Images { get; set; }
    }
