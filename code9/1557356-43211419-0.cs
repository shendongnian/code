    public class Customer
    {
        public int Id { get; set; }
    }
    class Program
    {
        static readonly XmlSerializer inNamespaceSerializer = new XmlSerializer(
             typeof(Customer), null, null,
             null, "my:namespace");
        static void Main()
        {
            inNamespaceSerializer.Serialize(Console.Out, new Customer { Id = 12345 });
        }
    }
