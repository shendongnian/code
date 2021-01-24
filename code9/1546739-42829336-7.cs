    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider))]
    public class MySampleClass
    {
        public int Property1 { get; set; }
        [Category("Extra")]
        public string Property2 { get; set; }
    }
