     [ServiceContract]
        [ServiceKnownType("GetAnimalsTypes", typeof(AnnimalsTypeProvider))]
        public interface IServicesServer : IAnimalService
        {
            IAnimal GetDog();
            void InsertCat(IAnimal cat);
        }
