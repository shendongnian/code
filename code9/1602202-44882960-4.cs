    class Program
    {
        static void Main(string[] args)
        {
            Tire black = new Tire()
            {
                Id = 5
            };
            Tire red = new Tire()
            {
                Id = 8
            };
            Tire purple = new Tire()
            {
                Id = 10
            };
            //Create my List
            List<Tire> mylist = new List<Tire>();
            mylist.Add(black);
            mylist.Add(red);
            mylist.Add(purple);
            //Define the car
            Car mycar = new Car()
            {
                Id = 20
            };
            mycar.TireList = mylist;
            foreach (var tire in mycar.TireList)
            {
                Console.WriteLine(tire.Id);
            }
            Console.ReadKey();
        }
    }
    public class Car
    {
        public int Id { get; set; }
        public List<Tire> TireList { get; set; }
    }
    public class Tire
    {
        public int Id { get; set; }
        public double Value { get; set; }
    }
