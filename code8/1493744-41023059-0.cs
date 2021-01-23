    class Program
    {
        static void Main(string[] args)
        {
            List<Lst> l = new List<Lst>();
            l.Add(new Lst("1stList"));
            Console.WriteLine("List {0}:", l.First(item => item.Name == "1stList").Name);
            Console.WriteLine("List {0}:", l.First(item => item.Name == "2ndList").Name);
            Console.ReadKey();
        }
    }
    public class Lst 
    {
        public string Name;
        public Lst(string Name) { this.Name = Name; }
    }
