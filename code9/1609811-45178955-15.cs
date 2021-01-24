    public class TabHeaderDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null)
                return null;
            var viewModel = item as VMBase;
            if (viewModel == null || viewModel.TabID != "02") 
                return null; //continue only if TabID is a match
            if (viewModel != null)
            {
                switch(viewModel.TabHeader)
                {
                    case "two":
                        return element.FindResource($"Template2") as DataTemplate;
                    case "three":
                        return element.FindResource($"Template3") as DataTemplate;
                }
            }
            return null;
        }
    }
