    public class Dog : Animal
    {
        public static readonly string ID = "dog";
        public override string GetId()
        {
            return ID;
        }
    }
    public abstract class Animal
    {
        public abstract string GetId();
    }
