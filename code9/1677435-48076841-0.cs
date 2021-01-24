    [ContentProperty("Conditions")]
    public class VisualStateInitializer : Behavior<FrameworkElement>
    {
        private bool _useTransitions = true;
        public bool UseTransitions
        {
            get { return _useTransitions; }
            set { _useTransitions = value; }
        }
        public List<VisualStateCondition> Conditions { get; set; }
        public VisualStateInitializer()
        {
            Conditions = new List<VisualStateCondition>();
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }
        
        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext == null)
                return;
            foreach (var item in Conditions)
            {
                var value = AssociatedObject.DataContext.GetType().GetProperty(item.PropertyName).GetValue(AssociatedObject.DataContext);
                    
                if (value != null && value.Equals(item.Value))
                    VisualStateManager.GoToElementState(AssociatedObject, item.DesiredState, UseTransitions);
            }
        }
    }
