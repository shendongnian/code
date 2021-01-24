    public class ImageWrapper
    {
       public string name { get; set; }
       public string type { get; set; }
       public ImageSource source { get; set; }
    }
    
    public class Expense : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ImageWrapper> Images { get; set; }//here
        public event PropertyChangedEventHandler PropertyChanged;
    }
