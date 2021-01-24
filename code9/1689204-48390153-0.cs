    public delegate void NumberAdded(Publisher source, NumberAddedEventArgs eventArgs);
    public class NumberAddedEventArgs : EventArgs
    {
        public NumberAddedEventArgs(int numberAdded, numberOfItemsInList)
        {
            NumberAdded = numberAdded;
            NumberOfItemsInList = numberOfItemsInList;
        }
        public int NumberAdded { get; private set; }
        public int NumberOfItemsInList { get; private set; }
    }
    public class Publisher
    {
        public event EventHandler NumberAddedEvent;
        public int NumberOfElementsInMyList;
        List<int> MyList = new List<int>();
        public void AddNumber(int NumberToAdd)
        {
            MyList.Add(NumberToAdd);
            NumberOfElementsInMyList = MyList.Count;
            NumberAddedEvent?.Invoke(this, new NumberAddedEventArgs(NumberToAdd, NumberOfElementsInMyList));
        }
    }
