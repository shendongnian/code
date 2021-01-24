    public class PropertyChangedBinding : Binding
    {
        public PropertyChangedBinding(string path)
            : base(path)
        {
            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
    
        public PropertyChangedBinding()
            : base()
        {
            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
        }
    }
