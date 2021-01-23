    public class FisPRepository : IFisPRepository
    {
        private readonly FISP _fisp;
    
        public FisPRepository(FISP fisp)
        {
            _fisp = fisp;
        }
    
        public person GetPersonFromId(string id)
        {
            return _fisP.getPerson(new personRequest()
            {
                reference = new referenceFilter { type = "FWI", value = id },
            });
        }
    }
