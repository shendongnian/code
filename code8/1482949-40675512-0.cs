    [JsonProperty(PropertyName = "content-exception")]
    public string content_exception { get; set; }
    [JsonProperty(PropertyName = "input-parameters")]
    public List<InputParameter> input_parameters { get; set; }
    [JsonProperty(PropertyName = "output-parameters")]
    public List<OutputParameter> output_parameters { get; set; }
    string json = File.ReadAllText("abc.txt");
    SampleClass obj = JsonConvert.DeserializeObject<SampleClass>(json);
    List<OutputParameter>  ls = obj.output_parameters;
