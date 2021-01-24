    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class Colours
    {
        public string ColourName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>()
            {
               new Person { Id = 1, Name = "Dave" },
               new Person { Id = 2, Name = "Joe" },
               new Person { Id = 3, Name = "Stephen"},
               new Person { Id = 4, Name = "Sue" },
               new Person { Id = 5, Name = "Jemma" },
               new Person { Id = 6, Name = "Sharon" },
            };
            Dictionary<int, Colours> Colours = new Dictionary<int, Colours>()
            {
                { 1, new Colours { ColourName = "Color.Red" }},
                { 2, new Colours { ColourName = "Color.Green"}},
                { 3, new Colours { ColourName = "Color.Blue"}},
            };
            Random RandomNumber = new Random();
            int ListPostionToRemoveAt = RandomNumber.Next(1, People.Count);
            int RandomColourPostion = RandomNumber.Next(1, Colours.Count);
            Person p = People[ListPostionToRemoveAt];
            
            Colours ColourToAssign = Colours[RandomColourPostion] ;
            p.Color = ColourToAssign.ColourName;
            Console.Write("Persons Name: " + p.Name +" Persons Colour:"+ p.Color);
            Console.ReadLine();
        }
    }
