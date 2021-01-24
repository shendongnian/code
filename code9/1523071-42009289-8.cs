    class MyTestClass
    {
        public const string DefaultText = "...";
        [DefaultValue(DefaultText)]
        [JsonProperty(PropertyName = "myText", DefaultValueHandling = DefaultValueHandling.Populate)]
        public readonly string Text;
        public MyTestClass([JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate), DefaultValue(DefaultText)] string text = DefaultText)
        {
            Text = text;
        }
    }
