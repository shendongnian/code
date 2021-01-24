    public class TaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            var vmBase = item as VMBase;
    
            if (element != null && vmBase != null)
            {
                switch(vmBase.TabID)
                {
                    case "Tab1": return element.FindResource("Tab1Template") as DataTemplate;
                    case "Tab2": return element.FindResource("Tab2Template") as DataTemplate;
                    default: return null;
                }
            }
        }
    }
