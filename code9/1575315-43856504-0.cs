    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
    public class Colours
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> People = new List<Person>();
            Dictionary<int, Colours> Colours = new Dictionary<int, Colours>()
            {
                { 1, new Colours { ColourName = "Color.Red", ColourId = 211 }},
                { 2, new Colours { ColourName = "Color.Green", ColourId = 211}},
                { 3, new Colours { ColourName = "Color.Blue", ColourId = 211 }},
            };
            People.Add(new Person { Id = 1, Name = "Dave" });
            People.Add(new Person { Id = 2, Name = "Joe" });
            People.Add(new Person { Id = 3, Name = "Stephen" });
            People.Add(new Person { Id = 4, Name = "Sue" });
            People.Add(new Person { Id = 5, Name = "Jemma" });
            People.Add(new Person { Id = 6, Name = "Sharon" });
            Random RandomNumber = new Random();
            int ListPostionToRemoveAt = RandomNumber.Next(1, People.Count);
            int RandomColourPostion = RandomNumber.Next(1, Colours.Count);
            Person GUY = People[ListPostionToRemoveAt];
            
            Colours ColourToAssign = Colours[RandomColourPostion] ;
            GUY.Color = ColourToAssign.ColourName;
            Console.Write(GUY.Name + " " + ColourToAssign.ColourName);
            Console.ReadLine();
        }
    }
