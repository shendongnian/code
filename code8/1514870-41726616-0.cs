    interface IRepository
    {
        void PersistData(object dataToBeSaved);
    }
    
    class DataSaver
    {
        private IRepository _repository;//this object's method PersistData makes a call to a database
        public DataSaver(IRepository repository)
        {
            _repository = repository;
        }
        public void Save(object dataToBeSaved)
        {
            _repository.PersistData(dataToBeSaved);
        }
    }
