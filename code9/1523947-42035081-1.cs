	public class Animal : IType
    {
        private static string _ID = "Animal";
        string IType.ID
        {
            get
            {
                return getID();
            }
        }
        public virtual string getID()
        {
            return _ID;
        }
    }
    public class Dog : Animal, IType
    {
        public static readonly string _dogID = "dog";
        string IType.ID
        {
            get
            {
                return _dogID;
            }
        }
        public override string getID()
        {
            return _dogID;
        }
    }
    ....
    // usage
    Animal a = new Animal();
    Animal d = new Dog();
    Console.WriteLine(a.getID());
    Console.WriteLine(d.getID());
    
