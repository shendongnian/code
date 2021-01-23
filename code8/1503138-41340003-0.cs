     internal class Locator : ViewModelLocator
            {
                private static readonly Lazy<Locator> _locator = new Lazy<Locator>(() => new Locator(), LazyThreadSafetyMode.PublicationOnly);
                public static Locator Instance => _locator.Value;
    
                private Locator()
                {
                    SimpleIoc.Default.Register<MainViewModel>();
                    SimpleIoc.Default.Register<AddStudentViewModel>();
                   
                }
    
                public MainViewModel Main
                {
                    get
                    {
                        return ServiceLocator.Current.GetInstance<MainViewModel>();
                    }
                }
                public AddStudentViewModel AddStudentViewModel
                {
                    get
                    {
                        return ServiceLocator.Current.GetInstance<QuestionsViewModel>();
                    }
                }
             
            } 
