    class DummyRepository : IRepository
    {
        public object DataJustSaved { get; set; }
        public void PersistData(object dataToBeSaved)
        {
            DataJustSaved = dataToBeSaved;
        }
    }
