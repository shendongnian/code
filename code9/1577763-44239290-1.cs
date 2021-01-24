    [NotifyPropertyChanged]
    public class TestClass
    {
        [AggregateAllChanges]
        public ObservableCollectionEx<TestItem> Items { get; } = new ObservableCollectionEx<TestItem>();
        [SafeForDependencyAnalysis]
        public int Sum
        {
            get
            {
                if (Depends.Guard)
                {
                    Depends.On(this.Items);
                }
                return this.Items.Sum(x => x.Value);
            }
        }
    }
    [NotifyPropertyChanged]
    public class TestItem
    {
        public int Value { get; set; }
    }
