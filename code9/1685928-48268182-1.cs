    public interface SmellInterface
    {
        string GetAdjective();
    }
    public class Smell
    {
        protected Smell() { }
        public string GetDescription()
        {
            // how do I call GetAdjective here?  I have no reference to it!
        }
    }
