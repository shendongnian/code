    internal abstract class IPropVisitor<A>
    {
        internal abstract A bindingMyText(ModelA source);
        internal abstract void bindingMyText(ModelA source, A val);
        internal abstract A bindingMyText(ModelB source);
        internal abstract void bindingMyText(ModelB source, A val);
    }
    internal class ViewModelVisitor : IPropVisitor<string>, INotifyPropertyChanged
    {
        internal ViewModelVisitor(ModelSource model)
        {
            modelSource = model;
            BindingMyText = "Test!";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        override internal string bindingMyText(ModelA source)
        {
            return source.MyTextA;
        }
        override internal void bindingMyText(ModelA source, string val)
        {
            source.MyTextA = val;
        }
        override internal string bindingMyText(ModelB source)
        {
            return source.MyTextB;
        }
        override internal void bindingMyText(ModelB source, string val)
        {
            source.MyTextB = val;
        }
        private ModelSource modelSource;
        public ModelSource ModelSource
        {
            get { return modelSource; }
            set
            {
                modelSource = value;
                OnPropertyChanged("ModelSource");
                OnPropertyChanged("BindingMyText");
            }
        }
        public string BindingMyText
        {
            get
            {
                return modelSource.accept(this); 
            }
            set
            {
                modelSource.accept(this, value);
                OnPropertyChanged("BindingMyText");
            }
        }
    }
