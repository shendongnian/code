    public abstract class FilterCreator<TFilter, TFilterType>
        where TFilter : Filter<TFilterType>
        where TFilterType : struct
    {
        public abstract TFilter Create(TFilterType type, string value);
    }
    
    public abstract class Filter<T>
        where T : struct
    {
        public T Type { get; set; }
        public string Value { get; set; }
    }
