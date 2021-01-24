    using System;
    using System.Windows;
    using System.Collections.Generic;
    using System.Windows.Interactivity;
    using System.Windows.Markup;
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
                var dataContextType = AssociatedObject.DataContext.GetType();
                System.Reflection.PropertyInfo propertyInfo;
                object value = null;
                var properties = item.PropertyName.Split('.');
                if (properties.Length > 1)
                {
                    for (int i = 0; i < properties.Length; i++)
                    {
                        if(value != null)
                        {
                            dataContextType = value.GetType();
                            propertyInfo = dataContextType.GetProperty(properties[i]);
                            value = propertyInfo.GetValue(value);
                        }
                        else
                        {
                            propertyInfo = dataContextType.GetProperty(properties[i]);
                            value = propertyInfo.GetValue(AssociatedObject.DataContext);
                        }
                    }
                }
                else
                {
                    value = AssociatedObject.DataContext.GetType().GetProperty(item.PropertyName).GetValue(AssociatedObject.DataContext);
                }
                if (value != null && value.Equals(item.Value))
                    VisualStateManager.GoToElementState(AssociatedObject, item.DesiredState, UseTransitions);
            }
        }
    }
