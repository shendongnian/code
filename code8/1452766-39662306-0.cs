    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for the relevant data
            Console.WriteLine("iveskite plytos ilgi - ");
            int ilgis = int.Parse(Console.ReadLine());
    
            Console.WriteLine("iveskite plytos auksti - ");
            int aukstis = int.Parse(Console.ReadLine());
    
            // Now we're in a position to create the object
            Plyta p1 = new Plyta(ilgis, aukstis);
            // And we can read the value back from the property
            Console.WriteLine(p1.Ilgis);
        }
    }
    class Plyta
    {
        // These are public, read-only automatically-implemented properties
        public int Ilgis { get; }
        public int Aukstis { get; }
    
        public Plyta(int ilgis, int aukstis)
        {
            // Set the properties...
            Ilgis = PlytosIlgis;
            Aukstis = PlytosAukstis;
        }
    }
