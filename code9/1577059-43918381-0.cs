    public interface IFilterBase<TItem>
    {
        PropertyInfo Property { get; } // can be used to display the property name etc.
        bool ApplyFilter(T value);
    }
