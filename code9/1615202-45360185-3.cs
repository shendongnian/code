    [XmlRootAttribute("MyClass", Namespace = "", IsNullable = false)]
    public class MyClass
    {
        private string comments;
        public string Comments
        {
            set { comments = value; }
            get { return comments; }
        }
        private System.Collections.Generic.List<string> tests = null;
        [XmlIgnore]
        public System.Collections.Generic.List<string> Tests
        {
            get { return tests; }
            set { tests = value; }
        }
        [XmlArray("Tests")]
        public string[] TestsArray
        {
            get
            {
                return (Tests == null ? null : Tests.ToArray());
            }
            set
            {
                if (value == null)
                    return;
                (Tests = Tests ?? new List<string>(value.Length)).AddRange(value);
            }
        }
    }
