    class Bag
    {
        public string Colour { get; }
        public int Volume { get; }
        public Bag(string c, int v)
        {
            Colour = c;
            Volume = v;
        }
    }
    
    class Program
    {
        static int CalcTotalVolumeIdx(List<Bag> bags, int i, int sum)
        {
            return (i >= bags.Count) ? sum :
                CalcTotalVolumeIdx(bags, i + 1, sum + bags[i].Volume);
        }
    
        static int CalcTotalVolume(List<Bag> bags)
        {
            return CalcTotalVolumeIdx(bags, 0, 0);
        }
    
        static void Main(string[] args)
        {
            List<Bag> bags = new List<Bag>();
            bags.Add(new Bag("Blue", 25));
            bags.Add(new Bag("Red", 35));
            bags.Add(new Bag("White", 30));
            int totalVolume = CalcTotalVolume(bags);
            Console.WriteLine("Total volume of bags: {0}", totalVolume);
        }
    }
