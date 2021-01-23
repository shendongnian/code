    public class EmptyDog : Dog
    {
       public override Name {get { throw new DogDoesNotExistException(); } }
       ...
    }
