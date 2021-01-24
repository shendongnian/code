    public class PropertyChangedBinding : Binding
    {
        public PropertyChangedBinding()
            :base()
        {
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
        public PropertyChangedBinding(string path)
            : base(path)
        {
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
    }
