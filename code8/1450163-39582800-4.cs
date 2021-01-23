    public class MyViewModel
    {
        public ObservableCollection<string> Data { get; set; }
        public MyViewModel()
        {
            Data = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
        }
    }
