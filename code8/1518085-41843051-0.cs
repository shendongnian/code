    public abstract class FilterableDescriptor
    {
        public string FilterValue { get; set; }
        public SortOrder SortOrder { get; set; } // Enum: SortOrder.Ascending, SortOrder.Descending
    }
