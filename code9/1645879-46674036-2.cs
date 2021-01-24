    public class IntegrationController : ApiController
    {
		private readonly IGenericRepository<Cat> _catRepo;
		private readonly IGenericRepository<Dog> _dogPackRepo;
        public IntegrationController(IGenericRepository<Cat> catRepository,
            IGenericRepository<Dog> dogRepository)
        {
			_catRepo = catRepository;
			_dogRepo = dogRepository;
        }
		
	[HttpGet]
    public AnimalDetails GetAnimalDetails(int tagId)
    {
        var animalDetails = new animalDetails();
        try
        {
            var dbName = getAnimalName(tagId);
            if (dbName == null)
            {
                animalDetails.ErrorMessage = $"Could not find animal name for tag Id {tagId}";
                return animalDetails;
            }
        }
        catch (Exception ex)
        {
            //todo: add logging
            Console.WriteLine(ex.Message);
            animalDetails.ErrorMessage = ex.Message;
            return animalDetails;
        }
        return animalDetails;
    }
    private string getAnimalName(int tagId)
    {
        try
        {            
             return _catRepo.Get().Where(s => s.TagId == 
               tagId.ToString()).SingleOrDefault();            
        }
        catch (Exception e)
        {
            //todo: add logging
            Console.WriteLine(e);
            throw;
        }
    }       
    }
 
