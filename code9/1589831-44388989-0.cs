    class Program
    {
        static void Main(string[] args)
        {
        }
        public static List<T> BuildList<T>() where T : IPersonModel, new()
        {
            //Populate list of T where T is wither a Person or PersonModel.
            //Return List of T
            // Implement here with any loop
            return null;// you need to return any value
        }
    }
    public interface IPersonModel
    {
        int ID { get; set; }
        string Name { get; set; }
        string Address { get; set; }
    }
    public class Person : IPersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class PersonModel : IPersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
