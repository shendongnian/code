    public sealed class ItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// This property is set in XAML.
        /// </summary>
        public DataTemplate NormalTemplate { get; set; }
        /// <summary>
        /// This property is set in XAML.
        /// </summary>
        public DataTemplate ThreeTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item)
        {
            if ("Three".Equals(item))
            {
                return ThreeTemplate;
            }
            return NormalTemplate;
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
