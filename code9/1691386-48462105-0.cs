    public class MainWindowVM : BaseVM
    {
        private IProjektInterface _projektService;
        public MainWindowVM()
        {
            _projektService = new ProjektService(new ProjektDbContext());
        }
    }
    public class ProjektService : BaseService
    { }
