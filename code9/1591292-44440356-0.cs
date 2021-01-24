    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new PrintFactory();
            Console.WriteLine(PrintFactory.GetPrint(PrintType.DigitalPrint));
            Console.WriteLine(PrintFactory.GetPrint(PrintType.InkPrint));
        }
    }
    
    public interface IPrint
    {
        void DoPrint();
    }
    
    public class DigitalPrint : IPrint
    {
        public void DoPrint()
        {
            // logic
        }
    }
    
    public class InkPrint : IPrint
    {
        public void DoPrint()
        {
            // logic
        }
    }
    
    public class PrintFactory
    {
        // Make the dictionary from PrintType to IPrint instead of IPrint to object
        private static IDictionary<PrintType, IPrint> prints = new Dictionary<PrintType, IPrint>();
        
        // Initialize prints in a static constructor.
        static PrintFactory()
        {
            prints.Add(PrintType.DigitalPrint, new DigitalPrint());
            prints.Add(PrintType.InkPrint, new InkPrint());
        }
        
        public static IPrint GetPrint(PrintType type)
        {
            if (!prints.ContainsKey(type)) 
            {
                // TODO: Maybe throw an exception or log?
            }
            return prints[type];
        }
    }
    public enum PrintType
    {
        DigitalPrint,
        InkPrint
    }
