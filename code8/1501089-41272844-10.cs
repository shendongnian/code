    using System;
    
    namespace AttributesNamespace
    {
        public sealed class DisplayAttribute : Attribute
        {
            public string Name { get; set; }
            public string BackgroundColor { get; set; }
        }
    }
