    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    
    namespace FormsDataGridViewBinding
    {
        public class Person : INotifyPropertyChanged
        {
            public Person(string n, string name, string address)
            {
                _number = n;
                _name = name;
                _address = address;
            }
               
            public string Number
            {
                get { return _number; }
                set
                {
                    if (_number != value)
                    {
                        _number = value;
                        this.NotifyPropertyChanged("Number");
                    }
                }
            }
    
            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        this.NotifyPropertyChanged("Name");
                    }
                }
            }
    
            public string Address
            {
                get { return _address; }
                set
                {
                    if (_address != value)
                    {
                        _address = value;
                        this.NotifyPropertyChanged("Address");
                    }
                }
            }
    
            private string _number;
            private string _name;
            private string _address;
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            private void NotifyPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
