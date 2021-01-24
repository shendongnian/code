        public class CCDataTemplateSelector: DataTemplateSelector
        {
          public DataTemplate FirstTemplate { get; set; }
          public DataTemplate SecondTemplate { get; set; }
          protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
          {
            var model = item as DemoModel;
            if (model == null)
                return null;
            if (model.ID >= 2)
                return FirstTemplate;
            else
                return SecondTemplate;
          }
        }
