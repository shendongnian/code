    public class YourCollection : ObservableCollection<MyObject>
    {
        // some wrapper functions for example:
        public void Add(string title)
        {  
           this.Add(new MyObject { Title = title });
        }
    }
