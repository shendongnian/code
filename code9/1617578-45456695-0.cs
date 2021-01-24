    public class ViewModel
    {
        private readonly Model MyModel;
    
        private int _actualReading;
        public int ActualReading
        {
            get { return _actualReading; }
            set { _actualReading = value; }
        }
    
        public ViewModel(Model model)
        {
            MyModel = model;
            ActualReading = model.ActualReading;
        }
    
        public Model GetModel()
        {
            MyModel.ActualReading = ActualReading;
    
            return MyModel;
        }
    }
