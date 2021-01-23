        //Other usings skipped for brevity
        ...
        ...
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
        // This is a simple user class that 
        // implements the IPropertyChange interface.
        public class DemoUser : INotifyPropertyChanged
        {
            // These fields hold the values for the public properties.
            private string userName = string.Empty;
            private string phoneNumber = string.Empty;
            public event PropertyChangedEventHandler PropertyChanged;
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
            public DemoUser()
            {
            }
            public string Id { get; set; }
            public string UserName
            {
                get
                {
                    return this.userName;
                }
                set
                {
                    if (value != this.userName)
                    {
                        this.userName = value;
                        NotifyPropertyChanged();
                    }
                }
            }
            public string PhoneNumber
            {
                get
                {
                    return this.phoneNumber;
                }
                set
                {
                    if (value != this.phoneNumber)
                    {
                        this.phoneNumber = value;
                        NotifyPropertyChanged();
                    }
                }
            }
        }
