    using System.ComponentModel;
    
    namespace WpfApp1
    {
        public class ColorViewModel : INotifyPropertyChanged
        {
            private byte red;
            public byte Red
            {
                get { return red; }
                set
                {
                    if (red != value)
                    {
                        red = value;
                        RaisePropertyChanged("Red");
                    }
                }
            }
    
            private byte green;
            public byte Green
            {
                get { return green; }
                set
                {
                    if (green != value)
                    {
                        green = value;
                        RaisePropertyChanged("Green");
                    }
                }
            }
    
            private byte blue;
            public byte Blue
            {
                get { return blue; }
                set
                {
                    if (blue != value)
                    {
                        blue = value;
                        RaisePropertyChanged("Blue");
                    }
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            private void RaisePropertyChanged(string propName)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
