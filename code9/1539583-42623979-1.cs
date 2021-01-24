    public class JobStatusItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SelectedTemplate { get; set; }
        public DataTemplate UnselectedTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = item as JobStatusItem;
            if (element == null) return UnselectedTemplate;
            return element.Selected ? SelectedTemplate : UnselectedTemplate;
        }
    }
