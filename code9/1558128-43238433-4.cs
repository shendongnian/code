    public class MyClassLookup : IMyClassLookup
    {
        private readonly IWhateverRepository _whateverRepository;
        public MyClassLookup(IWhateverRepository whateverRepository)
        {
            _whateverRepository = whateverRepository;
        }
        // IMyClassLookup implementations here that use _whateverRepository
    }
