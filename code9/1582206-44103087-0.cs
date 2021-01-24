    public partial class MainWindow : Window
    {
        ObservableCollection<Video> videos { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
    
            videos = new ObservableCollection<Video>
            {
                new Video {Name = "Video 1"},
                new Video {Name = "Video 2"},
                new Video {Name = "Video 3"}
            };
    
            VideoUIElment.ItemsSource = videos;
        }
    
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
    
            Video video = (Video)item.DataContext;
    
            MessageBox.Show(video.VideoMethod());
        }
    }
