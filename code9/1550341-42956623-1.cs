    public class MainViewModel
    {
            public List<News> Newss { get; set; }
            public MainViewModel()
            {
                 // This will initialize the collection when a new instance of
                 // your model is created
                 Newss = new List<News>();
            }
    }
