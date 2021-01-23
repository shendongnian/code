    public class AnimalFacotry
    {
        public IAnimal CreateAnimal(string animalType)
        {
             //Here you can either have a switch statement checking for
             //type, or use Type.GetType(animalType) and then create an
             //instance using the Activator - but in the latter case you will
             //need to pass in the exact type name of course 
        }
    }
     static void Main(string[] args)
     {
            var animalType = "Dog";
            var amimal = new AnimalFacotry().CreateAnimal(animalType);
            animal.Bark(); 
     }
