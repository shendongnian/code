    public interface IFoo
    {
        /// <summary>
        /// gets Bar
        /// </summary>
        string Bar();
    }
    public class Foo : IFoo
    {
        /// <summary>
        /// gets Bar
        /// </summary>        
        public string Bar() { return "Bar"; }
    }
