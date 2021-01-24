    public class MySampleClass
    {
        public string Name;
        public object Value;
    }
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BooleanTemplate
        {
            get;
            set;
        }
        public DataTemplate DoubleTemplate
        {
            get;
            set;
        }
        public DataTemplate StringTemplate
        {
            get;
            set;
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MySampleClass temp = item as MySampleClass;
            if(temp.Value is bool)
            {
                return BooleanTemplate;
            }
            else if(temp.Value is double)
            {
                return DoubleTemplate;
            }
            else if(temp.Value is string)
            {
                return StringTemplate;
            }
            else
            {
                return base.SelectTemplate(item, container);
            }
            
            // And so on
        }
    }
