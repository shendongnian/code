    namespace DocNanzDCMS.ViewModel
    {
        public class MainWindowViewModel : INotifyPropertyChanged
        {
            private MainWindowModel mainWindowModel;
            public Model {get {return mainWindowModel;}}
            public MainWindowViewModel()
            {
                this.mainWindowModel = new mainWindowModel();
            }
        }
    }
