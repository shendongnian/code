    class Program
    {
        public class Faker
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Faker(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        static void Main(string[] args)
        {
            var ls = new List<Faker>
            {
                new Faker(1, "A"),
                new Faker(2, "B")
            };
            Faker singleItem = ls.FirstOrDefault(x => x.Id == 1);
            IEnumerable<Faker> collectionWithSingleItem = ls.Where(x => x.Id == 1);
            Console.ReadLine();
        }
    }
