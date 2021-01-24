    interface IAnimal
    {
        int numberOfLegs { get; }
    }
    
    class Snake : IAnimal
    {
        public static int numberOfLegs = 0;
    
        int IAnimal.numberOfLegs
        {
            get { return numberOfLegs; }
        }
    }
    class Cat: IAnimal
    {
        public static int numberOfLegs = 4;
        int IAnimal.numberOfLegs
        {
            get { return numberOfLegs; }
        }
    }
