        public class ImgViewModel:INotifyPropertyChanged
        {    
            string _path ;
            public string Img {
    
                get { return _path; }
                set { _path = value; OnPropertyChanged("Img"); }        
            }
    
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            public void OnPropertyChanged(string prop)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    
        public class UriToImgConverter : IValueConverter
        {
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                BitmapImage img = new BitmapImage(new Uri(value.ToString(), UriKind.Relative));
                BitmapFrame frame = BitmapFrame.Create(img);
    
                return frame;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
