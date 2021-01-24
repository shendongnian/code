    using System.ComponentModel;
    
    namespace WpfApp1
    {
        public class ParentViewModel : INotifyPropertyChanged
        {
            private ColorViewModel color;
            public ColorViewModel Color
            {
                get { return color; }
                set
                {
                    if (color != value)
                    {
                        if (color != null)
                            color.PropertyChanged -= this.ChildPropertyChanged;
    
                        color = value;
    
                        if (color != null)
                            color.PropertyChanged += this.ChildPropertyChanged;
    
                        RaisePropertyChanged("Color");
                    }
                }
            }
    
            private void ChildPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (Color == sender)
                {
                    RaisePropertyChanged("Color");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            private void RaisePropertyChanged(string propName)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
