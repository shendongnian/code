    public class PetRepository : IPetRepository
    {
        private readonly PetStoreContext _context;
        public PetRepository(PetStoreContext context)
        {
            _context = context;
        }
        public List<Pet> GetAllPets()
        {
            return _context.Pet.ToList();
        }
     }
