    class Program
    {
        static void Main(string[] args)
        {
            var x = new Tests { 1, 2, 3 };
            var serializer = new XmlSerializer(typeof(Tests));
            serializer.Serialize(Console.Out, x);
        }        
    }
    [XmlRoot("Tests")]
    public class Tests : List<int>
    {
    }
