    public class StringContainsFilter<TItem> : IFilterBase<TItem>
    {
        public StringContainsFilter(PropertyInfo prop)
        {
            // TODO Requirements to check:
            // typeof(TItem).IsAssignableFrom(prop.DeclaringType)
            // typeof(string).IsAssignableFrom(prop.PropertyType)
        }
    
        // TODO Property getter implementation
    
        public string ContainedText { get; set; } // TODO INotifyPropertyChanged
    
        public bool ApplyFilter(TItem value)
        {
            // get the property value via reflection and check against the contains filter condition
            var text = Property.GetValue(value) as string ?? "";
            return text.Contains(ContainedText ?? "");
        }
    }
