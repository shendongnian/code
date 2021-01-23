    public class MyViewModel
    {
        public ObservableCollection<MyData> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<MyData>
            {
                new MyData {Logo = "logo1.png", Text = "playing 1" },
                new MyData {Logo = "logo2.png", Text = "playing 2" },
                new MyData {Logo = "logo3.png", Text = "playing 3" }
            };
        }
    }
