        public class SampleJson
        {
            [JsonProperty("date")]
            public string Date { get; set; }
            [JsonProperty("images")]
            public List<Image> Images { get; set; }
            // nested type, you can write it out of SampleJson object brackets
            class Image
            {
                 [JsonProperty("naturalHeight")]
                 public int NaturalHeight { get; set; }
                 [JsonProperty("width")]
                 public int Width { get; set; }
                 [JsonProperty("url")]
                 public string Url { get; set; }
                 [JsonProperty("naturalWidth")]
                 public int NaturalWidth { get; set; }
                 [JsonProperty("primary")]
                 public bool Primary { get; set; }
                 [JsonProperty("height")]
                 public int Height { get; set; }
                 [JsonProperty("title")]
                 public string Title { get; set; }
            }
        }
