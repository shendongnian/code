    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                int copy = i;
                Thread racer = new Thread(() => GetRacer(copy));
                racer.Start();
            }
            Console.ReadLine();
        }
        public static Racer GetRacer(int designation)
        {
            return new Racer(Convert.ToString(designation));
        }
    }
    public class Racer
    {
        public Racer(string name)
        {
            Random myRand = new Random(1234);
            Thread.Sleep(myRand.Next(1000, 2000));
            Console.WriteLine(name);
        }
    }
