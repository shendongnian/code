    public interface Animal { }
    public interface ICage
    {
       IEnumerable<IAnimal> Animals { get; set; }
    }
    public class Cage<TAnimal> where Animal: Animal
    {
        public IEnumerable<TAnimal> { get; set; } //Illegal implementation of ICage
    }
