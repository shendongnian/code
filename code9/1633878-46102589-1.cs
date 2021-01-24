        public class MyClassMetadata
        {
            [Category("My Properties")]
            [DisplayName("First Property")]
            [Description("This is the first Property.")]
            public string Property1 { get; set; }
            [Category("My Properties")]
            [DisplayName("Second Property")]
            [Description("This is the second Property.")]
            [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
            public string Property2 { get; set; }
        }
