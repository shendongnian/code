    public class ViewModel : ViewModelBase
    {
        #region Foo Property
        private String _foo = "Initial value of Foo";
        public String Foo
        {
            get { return _foo; }
            set
            {
                if (value != _foo)
                {
                    _foo = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(PropertyNameProp));
                    //  This works too, but all properties will be requeried.
                    //  In some cases that may be too expensive. 
                    //OnPropertyChanged(null);
                }
            }
        }
        #endregion Foo Property
        #region PropertyNameProp Property
        private String _propertyNameProp = "Foo";
        public String PropertyNameProp
        {
            get { return _propertyNameProp; }
            set
            {
                if (value != _propertyNameProp)
                {
                    _propertyNameProp = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion PropertyNameProp Property
    }
