     [ServiceContract]
     [ServiceKnownType("GetAnimalsTypes", typeof(AnimalsTypeProvider))]
     public interface IServicesServer : IAnimalService
     {
         IAnimal GetDog();
         void InsertCat(IAnimal cat);
     }
