    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
    
            Zoos = new ObservableCollection<Zoo>
          {
            new Zoo
            {
                ImageUrl = "http://wallpaper-gallery.net/images/image/image-13.jpg",
                Name = "Woodland Park Zoo"
            },
                new Zoo
            {
                ImageUrl =  "https://s3-us-west-1.amazonaws.com/powr/defaults/image-slider2.jpg",
                Name = "Cleveland Zoo"
                },
            new Zoo
            {
                ImageUrl = "http://i.stack.imgur.com/WCveg.jpg",
                Name = "Phoenix Zoo"
            }
        };
    
            //CarouselZoos.ItemsSource = Zoos;
            this.BindingContext = this;
            CarouselZoos.ItemSelected += CarouselZoos_ItemSelected;
        }
    
        private void CarouselZoos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Zoo;
            if (item == null)
                return;
            item.ImageUrl = "https://3.bp.blogspot.com/-W__wiaHUjwI/Vt3Grd8df0I/AAAAAAAAA78/7xqUNj8ujtY/s1600/image02.png";
        }
    
        public ObservableCollection<Zoo> Zoos { get; set; }
    }
    
    public class Zoo : INotifyPropertyChanged
    {
        private string _ImageUrl;
    
        public string ImageUrl
        {
            get { return _ImageUrl; }
            set
            {
                if (value != _ImageUrl)
                {
                    _ImageUrl = value;
                    OnPropertyChanged("ImageUrl");
                }
            }
        }
    
        private string _Name;
    
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value != _Name)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
