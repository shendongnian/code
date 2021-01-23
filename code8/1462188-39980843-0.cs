    [Serializable]
    [XmlRoot("Foos", Namespace="", IsNullable=false)]
    public partial class Foos {
        [XmlArrayItem ("Foo", IsNullable=false)] public Foo[] FooList { get; set; } }
    [Serializable] public partial class Foo {
        public string Bar { get; set; }
        [XmlIgnore] public string Stack { get; set; }
        [XmlElement("Stack", IsNullable=true)] 
        public XmlCDataSection StackCDATA {
          get { return new XmlDocument().CreateCDataSection(Stack ?? String.Empty); }
          set {
            Stack = value == null 
              ? String.Empty
              : ( String.IsNullOrWhiteSpace(value.Value)
                ? String.Empty
                : value.Value); } }
        public override string ToString() { return String.Format("Bar:{0} Stack:{1}", Bar, Stack); } }
