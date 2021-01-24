    // progid is now optional because we won't need CreateObject anymore
    [ProgId("One.Two.Three.SomeClass")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class SomeClass1
    {
        public SomeClass2 SomeFunction(string text)
        {
            return new SomeClass2 { Text = text };
        }
    }
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class SomeClass2
    {
        public string Text { get; set; }
    }
