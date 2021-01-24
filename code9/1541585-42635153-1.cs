    public class ViewModel
    {
        public ViewModel()
        {
             //populate the Models here 
        }
         
        ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models { get { return _models; } set { _models = value; } }
 
    }
