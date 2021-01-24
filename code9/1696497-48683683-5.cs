        public class MyViewSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object inItem, DependencyObject container)
            {
                if (inItem == null)
                {
                    return ResultTemplate;
                }
    
                if (inItem is DetailedViewModel)
                {
                    return DetailedTemplate;
                }
                if (inItem is ResultViewModel)
                {
                    return ResultTemplate;
                }
                if (inItem is ConfigurationViewModel)
                {
                    return ConfigurationTemplate;
                }
    
                return ResultTemplate;
            }
            
            public DataTemplate DetailedTemplate { get; set; }
            public DataTemplate ConfigurationTemplate { get; set; }
            public DataTemplate ResultTemplate { get; set; }
    
        }
