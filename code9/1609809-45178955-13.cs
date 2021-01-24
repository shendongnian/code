    public class TabIdDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null)
                return null;
            
            //var vm = item as VMBase;
            //var id = vm.TabId;
            string id = item as string;
            if (id != null)
            {
                return element.FindResource($"Tab{id}Template") as DataTemplate;
            }
            return null;
        }
    }
