    class MyTestClass
    {
        public const string DefaultText = "...";
        [DefaultValue(DefaultText)]
        [JsonProperty(PropertyName = "myText", DefaultValueHandling = DefaultValueHandling.Populate)]
        public readonly string Text;
        [JsonConstructor]
        MyTestClass()
            : this(DefaultText)
        {
        }
        public MyTestClass(string text = DefaultText)
        {
            Text = text;
        }
    }
