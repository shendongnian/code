    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ListObj>()
            {
                new ListObj()
                {
                    id = 111,
                    price1 = 10,
                    price2 = 20
                },
                new ListObj()
                {
                    id = 222,
                    price1 = 10,
                    price2 = 20
                },
                new ListObj()
                {
                    id = 111,
                    price1 = 30,
                    price2 = 70
                },
                new ListObj()
                {
                    id = 444,
                    price1 = 15,
                    price2 = 25
                },
            };
            var combined = list
                .GroupBy(x => x.id, x => x)
                .Select(x => new ListObj()
                {
                    id = x.Key,
                    price1 = x.Sum(s => s.price1),
                    price2 = x.Sum(s => s.price2),
                });
            Console.ReadKey();
        }
    }
    public class ListObj
    {
        public int id { get; set; }
        public int price1 { get; set; }
        public int price2 { get; set; }
    }
