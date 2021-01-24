    public interface IAnimal 
    {
    }
    
    public interface IDog : IAnimal
    {
    }
    
    public interface ICat : IAnimal
    {
    }
    
    public class Animal : IAnimal
    {
    }
    
    public class Dog : Animal, IDog
    {
    }
    
    public class Cat : Animal, ICat
    {
    }
    
    Animal animal = null;
    var dog = new Dog();
    var cat = new Cat();
    
    animal = dog; //Success
    animal = cat; //Success
    cat = (Cat)animal; //Success because animal is a cat.
    dog = (Dog)animal; //Fail because animal is a cat.
    //The above is the same as attempting to do:
    dog = cat;
