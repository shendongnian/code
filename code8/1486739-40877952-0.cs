    public abstract class ContentBase
    {
        public string elementC { get; set; }
    }
    public class ContentA : ContentBase
    {
        public VariousTypeA variousTypeA { get; set; }
    }
    public class ContentB : ContentBase
    {
        public VariousTypeB variousTypeB { get; set; }
    }
