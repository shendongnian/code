    public class Setup : MvxAndroidSetup
    {
        private readonly Context _applicationContext;
        public Setup(Context applicationContext) : base(applicationContext)
        {
            // save copy of application context
            _applicationContext = applicationContext;
        }
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            // instantiate and register helper
            Mvx.RegisterSingleton<ILocalizationHelper>(new LocalizationHelper(_applicationContext));
        }
    }
    public class MyViewModel : MvxViewModel
    {
        private readonly ILocalizationHelper _localizationHelper;
        // constructor injector of helper singleton
        public MyViewModel(ILocalizationHelper localizationHelper)
        {
            _localizationHelper = localizationHelper;
            // you will now be able to use _localizationHelper from the rest of the ViewModel
        }
    }
