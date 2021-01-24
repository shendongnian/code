        internal class Program
    {
        private static void Main(string[] args)
        {
            Toyota t = new Toyota() { EngineType = new EngineType() };
            Console.WriteLine(t.DisplayName);
            Console.ReadLine();
        }
    }
    public class CarsBase
    {
        public string DisplayName { get; set; }
    }
    public class Toyota : CarsBase
    {
        public EngineType EngineType { get; set; }
        public Toyota()
        {
            // set the default Display Name
            // that way you don't have to set it everytime
            this.DisplayName = "Oh what a feeling!";
        }
    }
    public class EngineType { }
