    public abstract class FourLeggedAnimal
    {
        public int GetLegCount()
        {
            return 4;
        }
    }
    public class Dog : FourLeggedAnimal
    {
        public string GetScientificName()
        {
            return "doggus scientificus";
        }
    }
    public class Cat : FourLeggedAnimal
    {
        public string GetServant()
        {
            return "human";
        }
    }
    public class AnimalInformer
    {
        public void DisplayInformation(FourLeggedAnimal animal)
        {
            Console.WriteLine("It has {0} legs", animal.GetLegCount());
    
            if (animal is Dog)
                Console.WriteLine("Its scientific name is {0}", ((Dog)animal).GetScientificName());
            if (animal is Cat)
                Console.WriteLine("Its servant is {0}", ((Cat)animal).GetServant());
        }
    }
