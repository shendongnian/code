    public class Model 
    {
        public List<object> Plugins { get; set; }
    }
    public class ViewModel : Model 
    {
        public new ObservableCollection<object> Plugins { get; set; }
    }
