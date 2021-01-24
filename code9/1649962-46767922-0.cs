    public class AdaptItem
    {
        public Windows.UI.Xaml.Media.Imaging.BitmapImage Image { get; set; }
        public static ObservableCollection<AdaptItem> AdaptList()
        {
            ObservableCollection<AdaptItem> pics = new ObservableCollection<AdaptItem>()
            {
                new AdaptItem
                {
                    Image = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/01.jpg"))
                },
                new AdaptItem
                {
                    Image = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/02.png"))
                },
                new AdaptItem
                {
                    Image = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx:///Assets/03.png"))
                },
            };
            return pics;
        }
    }
