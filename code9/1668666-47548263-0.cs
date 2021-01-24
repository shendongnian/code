    public class ColorItem: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            public Color color
            {
                get
                {
                    return _color;
                }
                set
                {
                    _color = value;
                    this.OnPropertyChanged();
                }
            }
    
            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                // Raise the PropertyChanged event, passing the name of the property whose value has changed.
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
