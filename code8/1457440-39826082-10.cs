    public class MainViewModel : BindableBase
      {      
        public MainViewModel()
        {
            _model = new Model {Name = "Test"};
        }
        private Model _model;
        public Model Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged("Model");       
            }
        }
    }
  
