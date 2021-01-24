    public interface IFoo
    {
        /// <summary>
        /// gets Bar
        /// </summary>
        string Bar();
    }
    public class Foo : IFoo
    {
        /// <inheritdoc />       
        public string Bar() { return "Bar"; }
    }
