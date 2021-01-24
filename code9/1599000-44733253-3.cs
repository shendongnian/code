    [ComVisible(true)]
    [ProgId("One.Two.Three.SomeClass")]
    public class SomeClass1
    {
        public SomeClass2 SomeFunction(string text)
        {
            return new SomeClass2 { Text = text };
        }
    }
    [ComVisible(true)]
    public class SomeClass2
    {
        public string Text { get; set; }
    }
