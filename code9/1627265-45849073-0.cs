        public class DemoCustomer : INotifyPropertyChanged
            {
        public event PropertyChangedEventHandler PropertyChanged;
        
    //NotifyPropertyChanged
    
        // This method is called by the Set accessor of each property.
                // The CallerMemberName attribute that is applied to the optional propertyName
                // parameter causes the property name of the caller to be substituted as an argument.
                private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
        
        //Property:
        
        public string CustomerName
                {
                    get
                    {
                        return this.customerNameValue;
                    }
        
                    set
                    {
                        if (value != this.customerNameValue)
                        {
                            this.customerNameValue = value;
                            NotifyPropertyChanged();
                        }
                    }
                }
        }
