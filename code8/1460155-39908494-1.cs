    public class MySpecialViewModel : ViewModelBase
    {
        public BitmapSource imageSource { get; set; }
        public BitmapSource ImageSource { get { return imageSource; }
            set { if (value != imageSource)
                {
                    imageSource = value;
     RaisePropertyChanged("ImageSource");
                }
            } }
    
        public MySpecialViewModel()
        {
            //gets displayed
            ImageSource = new BitmapImage(new Uri("C:\\Users\\user\\Pictures\\test.jpg"));
    
            //gets displayed aswell
            Task.Run(() => changeImage(10000, "C:\\Users\\user\\Pictures\\clickMe.png"));
        }
    
        public async void changeImage(int sleep, string uri)
        {
            await Task.Delay(sleep);
            BitmapSource source = new BitmapImage(new Uri(uri));
            source.Freeze();
            ImageSource = source;
        }
    
    }
