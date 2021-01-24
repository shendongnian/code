        using System.ComponentModel;
        using System.Windows.Media;
        
        namespace WpfDatabase
        {
            public class ViewModel:INotifyPropertyChanged
            {
                private ImageBrush _background;
                public ImageBrush Background
                {
                    get { return _background; }
                    set { _background = value; OnPropertyChanged("Background"); }
                }
                
                public event PropertyChangedEventHandler PropertyChanged = delegate { };
                private void OnPropertyChanged(string prop)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }
        }
