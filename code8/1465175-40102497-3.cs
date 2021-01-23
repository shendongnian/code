    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NullTemplate { get; set; }
        public DataTemplate CustomTemplate1 { get; set; }
        public DataTemplate CustomTemplate2 { get; set; }
    
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var model = item as ContentControlDataModel;
            if (model == null || model.Template == null)
                return this.NullTemplate;
            else
            {
                return (bool)model.Template ? this.CustomTemplate1 : this.CustomTemplate2;
            }
        }
    }
