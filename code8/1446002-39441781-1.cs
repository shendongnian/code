    public class MyViewModel
    {
        public ObservableCollection<string> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<string>
            {
                "playing 1",
                "playing 2",
                "playing 3",
            };
        }
    }
