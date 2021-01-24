    public class ViewModelLine
    {
        public ViewModelLine()
        {
            _models = new ObservableCollection<ModelLine>(); 
        }
        ObservableCollection<ModelLine> _models;
        public ObservableCollection<ModelLine> Models { get { return _models; } set { _models = value; } }
    }
