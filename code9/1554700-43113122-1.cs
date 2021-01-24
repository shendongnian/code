    public interface IPetFood { }
    public interface IPetSound { }
    public interface IPetCage<in S, out T>
        where S : IPetFood
        where T : IPetSound
    {
        T Feed(S s);
    }
    public class DogFood : IPetFood { }
    public class CatFood : IPetFood { }
    public class Bark : IPetSound { }
    public class DogCage : IPetCage<DogFood, Bark>
    {
        public Bark Feed(DogFood input)
        {
            return new Bark();
        }
    }
