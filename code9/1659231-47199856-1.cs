    public class MyViewModel
    {
        public ObservableCollection<Tuple<int,int>> Data { get; set; }
    
        public MyViewModel()
        {
            Data = new ObservableCollection<Tuple<int, int>>();
    
            Random y = new Random();
    
            for (int x = 0; x < 15; x++)
                Data.Add(new Tuple<int, int>(x, y.Next(100)));
    
        }
    }
