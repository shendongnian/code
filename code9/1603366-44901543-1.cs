     public class Dog : Animal
      {
        public Dog(Type animalType) : base(animalType)
        {
            
        }
        public static int CountDogs
        {
            get { return AnimalList.Count(x => x == typeof (Dog)); }
        }
      }
