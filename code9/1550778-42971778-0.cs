    public abstract class SubClass : BaseClass
    {
        public ObservableCollection<int> ObservableNumbers
        {
            get { return (ObservableCollection<int>)Numbers; }
            set { Numbers = value; }
        }
    }
