    [RoutePrefix("Animals")]
    public class AnimalsController : ApiController
    {
        public List<Animal> Get()
        {
            List<Animal> animals = new AnimalList(); 
            animals.Add(new FlyingAnimal());
            animals.Add(new SwimmingAnimal());
            return animals;
        }
    }
