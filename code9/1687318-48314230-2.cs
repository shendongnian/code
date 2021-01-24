    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                DateTime dummyDate = DateTime.Now.AddMonths(-i).AddDays(-(i * i));
                MovieItem item = new MovieItem()
                {
                    ImageSource = $"http://fakeimg.pl/100x200/?text=Image_{i}",
                    Title = $"Dummy movie {i}",
                    Year = $"{dummyDate.Year}",
                    ReleaseDate = $"{dummyDate.ToLongDateString()}"
                };
                moviePresenter.Items.Add(item);
            }
        }
    }
