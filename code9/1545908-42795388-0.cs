    public class ExtendedListBoxDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CheckedListBoxTemplate { get; set; }
    
        public DataTemplate ListBoxTemplate { get; set; }
    
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (container == null || !(container is ExtendedListBox))
            {
                return base.SelectTemplate(item, container);
            }
    
            var listBox = (ExtendedListBox)container;
    
            switch (listBox.DisplayAs)
            {
                case ExtendedListBoxDisplay.CheckedListBox:
                    return CheckedListBoxTemplate;
                case ExtendedListBoxDisplay.ListBox:
                    return ListBoxTemplate;
                default:
                    return base.SelectTemplate(item, container);
    
            }
        }
    }
