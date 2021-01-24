    public sealed partial class MainPage : Page
    {
        public List<ItemClass> Items = new List<ItemClass>();
        public MainPage()
        {
            Items.Add(new ItemClass { Name = "First item", Image = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")) });
            Items.Add(new ItemClass { Name = "Second item", Image = new BitmapImage(new Uri("ms-appx:///Assets/StoreLogo.png")) });
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Items[1].Image = new BitmapImage(new Uri("ms-appx:///test.jpg"));
    }
    public class ItemClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private ImageSource image;
        public ImageSource Image
        {
            get { return image; }
            set { image = value; RaiseProperty(nameof(Image)); }
        }
        public string Name { get; set; }
    }
