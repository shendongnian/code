    namespace YourNamespace
    {
        [MetadataType(typeof(SomeClassMetadata))]
        public partial class SomeClass
        {
            //add your new properties/some_logic here
             
            public string NewPropX { get; set; }
            public string NewPropY { get; set; }
        }
        public partial class SomeClassMetadata
        {
            //metadata for your existing model properties
            [Display(Name = "Property 1")]
            public string Prop1 { get; set; }
            [Display(Name = "Property 2")]
            public string Prop2 { get; set; }
        }
    }
