    public abstract class BaseClass<T> where T : ICollection<int>
        {
            public T Numbers { get; set; }
        }
    
        public abstract class SubClass : BaseClass<ObservableCollection<int>>
        {
            
        }
