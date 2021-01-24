    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
    
            dataGrid = new DataGrid();
    
            var stackPanel = new StackPanel { Orientation = Orientation.Vertical };
            stackPanel.Children.Add(dataGrid);
    
            Content = stackPanel;
    
            Rnd = new Random();
            Now = DateTime.Now;
            Counter = 1;
    
            foreach (var song in GetSongs())
                dataGrid.Items.Add(song);
    
            // var timeSpanConverter = new TimeSpanConverter();
            var titleColumn = new DataGridTextColumn { Header = "Title", Binding = new Binding("Title") };
            var authorColumn = new DataGridTextColumn { Header = "Author", Binding = new Binding("Author") };
            var albumColumn = new DataGridTextColumn { Header = "Album", Binding = new Binding("Album")};
            // var durationColumn = new DataGridTextColumn {Header = "Duration", Binding = new Binding("Duration") { Converter = timeSpanConverter }   };
            var durationColumn = new DataGridTextColumn { Header = "Duration", Binding = new Binding("Duration") { StringFormat = "mm\\:ss" } };
            var releaseColumn = new DataGridTextColumn { Header = "Release", Binding = new Binding("Release") { StringFormat = "yyyy-MM-dd" } };
    
            dataGrid.Columns.Add(titleColumn);
            dataGrid.Columns.Add(authorColumn);
            dataGrid.Columns.Add(albumColumn);
            dataGrid.Columns.Add(durationColumn);
            dataGrid.Columns.Add(releaseColumn);
        }
    
        private DataGrid dataGrid;
    
        private int? Counter;
        private DateTime? Now;
        private Random Rnd;
    
        private TimeSpan GetDuration() { return TimeSpan.FromSeconds(30 + Rnd.Next(500)); }
        private DateTime GetRelease() { Counter += 1; return Now.Value.AddMilliseconds(Counter.Value); }
        private string GetTitle() { return $"Title {Counter}"; }
        private string GetAlbum() { return $"Album {Counter}"; }
        private string GetAuthor() { return $"Author {Counter}"; }
    
        private IList<Song> GetSongs()
        {
            var list = new List<Song>();
    
            for(var i = 0; i < 1000; i++)
                list.Add(new Song() {
                    Title = GetTitle(),
                    Album = GetAlbum(),
                    Author = GetAuthor(),
                    Release = GetRelease(),
                    Duration = GetDuration()
                });
            return list;
        }
    }
    
    public class Song {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public DateTime Release { get; set; }
        public TimeSpan Duration { get; set; }
    }
    
    public class TimeSpanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((TimeSpan)value).ToString("mm\\:ss");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
