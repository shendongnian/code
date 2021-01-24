        public class RootObject
        {
            // This member will prevent RootObject from being serialized by XmlSerializer despite the fact that the ShouldSerialize method always returns false.
            // To make RootObject serialize successfully, [XmlIgnore] must be added.
            public NoDefaultConstructor NoDefaultConstructor { get; set; }
            public bool ShouldSerializeNoDefaultConstructor() { return false; }
        }
        public class NoDefaultConstructor
        {
            public string Name { get; set; }
            public NoDefaultConstructor(string name) { this.Name = name; }
        }
    cannot be serialized by `XmlSerializer`.
