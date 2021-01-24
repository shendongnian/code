    public class MyDataTemplateSelector : DataTemplateSelector 
    { 
        public Dictionary<Type, DataTemplate> TemplateDictionary { get; set; } 
        protected override DataTemplate SelectTemplateCore(object item) 
        { 
            // select datatemplate depending on item type 
            Type itemType = item.GetType(); 
            if (!TemplateDictionary.Keys.Contains(itemType)) 
            { 
                return null; 
            } 
            return TemplateDictionary[itemType]; 
        } 
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container) 
        { 
            // select datatemplate depending on item type 
            Type itemType = item.GetType(); 
            if (!TemplateDictionary.Keys.Contains(itemType)) 
            { 
                return null; 
            } 
            return TemplateDictionary[itemType]; 
        } 
    }
