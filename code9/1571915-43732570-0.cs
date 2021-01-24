    public class MyViewModel : INotifyPropertyChanged
    {
        private readonly MyView view;
        private ModelAndUserControl model;
    
        public MyViewModel(MyView view, ModelAndUserControl model) 
        {
            this.view = view;
            this.model = model;
            this.model.PropertyChanged += Model_PropertyChanged;
        }
    
        // Debugging reveals that the value of the formatted 
        // string, changes correctly when the model property changes.
        // But the change isn't reflected in the view.
        public string FormattedPrice
        {
            get { return string.format("{0:n0} EUR", model.Price); }
        }
        
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName){
                case "Price":
                    InvokePropertyChanged("FormattedPrice");
                    break;
                default:
                    break;
            }
        }
        
        // Implement INotifyPropertyChanged        
        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
