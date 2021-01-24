    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        void Method();
    }
    public class Program
    {
        static void Main(string[] args)
        {
           //Dynamic Expando object
            var p = CreateProxyObject<IPerson>(new Dictionary<string, object>
                                           {
                                               {"Name", "a name"},
                                               {"Age", 13}
                                           });
            var n = p.Name;
            var a = p.Age;
            //Throws: 'System.Dynamic.ExpandoObject' does not contain a definition for 'Method'
            p.Method();
        }
    }
