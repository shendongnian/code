    public class myCustomModel1Controller: ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();       
        private IRepository _repo = new Repository();
        [EnableQuery]
        public IEnumerable<myCustomModel1> GetmyCustomModel1([FromODataUri] int key)
        {          
            return _repo.FetchDataForcustomModel1(key);
        }
    }
