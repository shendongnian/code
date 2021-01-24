    public abstract class BaseClass
        {
            public virtual ICollection<int> Numbers { get; set; }
        }
    
        public abstract class SubClass : BaseClass
        {
            public new ObservableCollection<int> Numbers { get; set; }
        }
