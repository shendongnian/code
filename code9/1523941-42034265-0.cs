    public class Animal
    {
        public static string Id;
        public virtual string GetId()
        {
            return Id;
        }
    }
    public class Dog : Animal
    {
        public new static readonly string Id = "dog";
        public override string GetId()
        {
            return Id;
        }
    }
