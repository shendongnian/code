    public class ColBTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ValidDataTemplate { get; set; }
        public DataTemplate InvalidDataTemplate { get; set; }
        
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var tempItem = (item as YourDataItem);
            if (tempItem == null || tempItem.IsColPropertyAInvalid()) return InvalidDataTemplate;
            return ValidDataTemplate;
        }
    }
