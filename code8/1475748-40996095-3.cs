    public class MyTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// This property is set from XAML.
        /// </summary>
        public DataTemplate EmployeeTemplate { get; set; }
        /// <summary>
        /// This property is set from XAML.
        /// </summary>
        public DataTemplate CertifyingTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Employee)
            {
                return EmployeeTemplate;
            }
            if (item is Certifying)
            {
                return CertifyingTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
