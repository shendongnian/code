    enum AnimalType
    {
    Horse,
    Dog,
    Cat
    }
    class Animal
    {
    public AnimalType Type;
    }
    class Animals
    {
    public Animal[] Animals { get; }
    }
    ProcessAnimals(Animals animals)
    {
    // do something with animals.Animals array
    }
