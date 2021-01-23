    namespace DemoWPFApp1.ViewModels
    {
        public class MainWindowViewModel : BaseViewModel
        {
            private string m_boundProperty;
            public string BoundProperty
            {
                get
                {
                    return m_boundProperty;
                }
                set
                {
                    m_boundProperty = value; OnPropertyChanged();
                }
            }
    
            public MainWindowViewModel()
            {
                BoundProperty = "Some value.";
            }
        }
    }
