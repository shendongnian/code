    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Insert the type of boeing that u are using");
            //string sname = Console.ReadLine();
            //int ifuel = int.Parse(Console.ReadLine());
            Console.WriteLine(" here are 5 different type of boeing:");
            string sname = "";
            int ifuel = 0;
            int i;
            int[] fuellist = new int[5] { 99, 98, 92, 97, 95 };
            var nameslist = new string[5]  { "XXA1", "XXA2", "XXA3","XXA4","XXA5"};
            //var arr3 = new string[] { "one", "two", "three" };
                        
            for (i = 0; i < 5; i++)
            {
                ifuel = fuellist[i];
                sname = nameslist[i];
                Boeing737 boeing = new Boeing737(name: "Boeing737" + sname, fuel: ifuel, tons: 0);
                Console.WriteLine("{0} has {1} tons of fuel and weights {2}", boeing.Name, boeing.Fuel, boeing.Tons);
               
            }
            //Boeing737 boeing = new Boeing737(name: "Boeing737" + sname, fuel: ifuel, tons: 0);
            Console.ReadKey();
        }    
    }
    public class Planes
    {
        public Planes(string name, int fuel, int tons)
        {
            Name = name;
            Fuel = fuel;
            Tons = tons;
        }
        public int Tons;
        public int Fuel;
        public string Name { private set; get; }
    }
    class Boeing737 : Planes
    {
        public Boeing737(string name, int fuel, int tons) : base(name, fuel, tons)
        {
            Tons = 700;
        }
    }
