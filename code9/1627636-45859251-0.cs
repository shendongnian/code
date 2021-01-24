    public class MyCollection : ObservableCollection<MyClass>
    {
        public new MyClass this[int index]
        {
            get { return base[index]; }
            set 
            {
                base[index] = value;
                base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }
