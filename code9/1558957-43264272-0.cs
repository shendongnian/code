    public class MyCollection<T> : ObservableCollection<T>
    {
        public IEnumerable<T> TopItems
        {
            get { return this.Take(3); }
        }
    }
