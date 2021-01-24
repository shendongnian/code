    public class Displayer
    {
        public Displayer()
        {
            Lines = new ObservableCollection<string>();
            Lines.CollectionChanged += Update; // Update will be called automatically when ever collection changes.
        }
        public ObservableCollection<string> Lines { get; }
        private void Update(object sender, NotifyCollectionChangedEventArgs args)
        {
            // update console only once
            Console.Clear();
            foreach (string s in Lines)
            {
                Console.WriteLine(s);
            }
        }
    }
