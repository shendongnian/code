    public class Adress
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(150)]
        public string Gatunamn { get; set; }
        public string Postnummer { get; set; }
        [MaxLength(150)]
        public string Postort { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var Db = new ApplicationDbContext();
            var person = new Person()
            {
                Name = "Test name"
            };
            var adress = new Adress()
            {
                Postnummer = "Test",
                Person = person
            };
            Db.Adresses.Add(adress);
            Db.SaveChanges();
        }
    }
