    public class HomeViewSelector : DataTemplateSelector
    {
        public DataTemplate ViewTemplate1 { get; set; }
        public DataTemplate ViewTemplate2 { get; set; }
        public DataTemplate ViewTemplate3 { get; set; }
        public DataTemplate ViewTemplate4 { get; set; }
    
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var tab = (ViewTab)item;
            DataTemplate template = null;
    
            switch (tab.SelectedTab)
            {
                case CarouselViewTabs.View1:
                    template = ViewTemplate1;
                    break;
                case CarouselViewTabs.View2:
                    template = ViewTemplate2;
                    break;
                case CarouselViewTabs.View3:
                    template = ViewTemplate3;
                    break;
                case CarouselViewTabs.View4:
                    template = ViewTemplate4;
                    break;
                default:
                    throw new NotSupportedException();
            }
    
            return template;
        }
    }
