    class Program
    {
        enum Planet
        {
            Mercury = 1, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What Planet Are You Looking For? Pluto is a planet! 1-9? ");
            string planet1 = System.Console.ReadLine();
            Planet planet = (Planet)Convert.ToInt32(planet1);
            System.Console.WriteLine(planet);
        
            System.Console.WriteLine();
            System.Console.ReadLine();
