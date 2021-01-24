    public interface IAnimal
    {
        string MakeSound();
    }
   
    public class Cow : IAnimal
    {
        public string MakeSound()
        {
            return "Moo";
        }
    }
    public class Giraffe : IAnimal
    {
        public string MakeSound()
        {
            return "I don't make any sound. Bad example.";
        }
    }
