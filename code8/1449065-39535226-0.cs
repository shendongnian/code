    public interface IAnimal //IInterfaceA
    public interface ICat : IAnimal //IInterfaceB
    public interface IDog : IAnimal //another IInterfaceB
    IAnimal someAnimal = GetMeADog();
    ICat catAndDogsDontMix = (ICat)someAnimal; //ouch!
