    public class MyImageSource : ImageSource
    {
       public string name { get; set; }
       public string type { get; set; }
    }
    
    public class Expense : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<MyImageSource> Images { get; set; }//here
        public event PropertyChangedEventHandler PropertyChanged;
    }
