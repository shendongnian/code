    public class OutsideClass
    {
        // Define field or properties to store nested types
        public Select Pick { get; set; }   
        public NestedClass Link { get; set; }
        // Type definitions
        public class NestedClass
        {
        }
        public enum Select
        {
            None,
            One,
            Many,
            All
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OutsideClass a = new OutsideClass();
            a.Pick=OutsideClass.Select.Many;
            a.Link=new OutsideClass.NestedClass();
        }
    }
