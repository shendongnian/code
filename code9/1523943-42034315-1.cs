    public abstract class Animal
    {
        // Now you can access Id property implementation 
        // from Animal
        public abstract string Id { get; }
    }
    
    public class Dog : Animal
    {
        public override string Id { get; } = "dog";
    }
