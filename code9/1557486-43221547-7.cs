    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public TemplateCollection Templates { get; set; }
        private ICollection<Template> _templateCache { get; set; }
        public MyDataTemplateSelector()
        {
        }
        private void InitTemplateCollection()
        {
            _templateCache = Templates.ToList();
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (_templateCache == null)
            {
                InitTemplateCollection();
            }
            if (item != null)
            {
                var dataType = item.GetType().ToString();
                var match = _templateCache.Where(m => m.DataType == dataType).FirstOrDefault();
                if (match != null)
                {
                    return match.DataTemplate;
                }
            }
            return base.SelectTemplateCore(item, container);
        }
    }
