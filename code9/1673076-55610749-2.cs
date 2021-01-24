    public class PropertyChangedExtendedEventArgs : PropertyChangedEventArgs
    {
            public virtual object OldValue { get; private set; }
            public virtual object NewValue { get; private set; }
    
            public PropertyChangedExtendedEventArgs(string propertyName, object oldValue, 
                   object newValue)
                   : base(propertyName)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
        }
    public class NotifyObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void NotifyPropertyChanged(string propertyName, object oldvalue, object newvalue)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedExtendedEventArgs(propertyName, oldvalue, newvalue));
            }
        }
 
    public class Person : NotifyObject
        {
            private int _name;
            public int Name
            {
                get { return _name; }
                set
                {
                    var oldValue = _name;
                    _name = value;
                    NotifyPropertyChanged("Name", oldValue, value);
    
                }
            }
        }
