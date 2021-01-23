    public class MyItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is MyItem)
            {
                var myItem = item as MyItem;
                var window = Application.Current.MainWindow;
                switch (myItem.SpecialFeatures)
                {
                    case SpecialFeatures.None:
                        return 
                            element.FindResource("Item_None_DataTemplate") 
                            as DataTemplate;
                    case SpecialFeatures.Color:
                        return 
                            element.FindResource("Item_Color_DataTemplate") 
                            as DataTemplate;
                }
            }
            return null;
        }
    }
      
