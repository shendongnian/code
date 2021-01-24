    public class YourCollection : ObservableCollection<MyObject>
    {
        public void Add(string title)
        {  
           this.Add(new MyObject { Title = title });
        }
    }
