    public class ElementSpy : Freezable
    {
        private DependencyObject element;
            
        public static ElementSpy GetNameScopeSource(DependencyObject obj)
        {
            return (ElementSpy)obj.GetValue(NameScopeSourceProperty);
        }
    
        public static void SetNameScopeSource(DependencyObject obj, ElementSpy value)
        {
            obj.SetValue(NameScopeSourceProperty, value);
        }
    
        public static readonly DependencyProperty NameScopeSourceProperty =
            DependencyProperty.RegisterAttached("NameScopeSource", typeof(ElementSpy), typeof(ElementSpy),
                new UIPropertyMetadata(null, OnNameScopeSourceProperty));
    
        private static void OnNameScopeSourceProperty(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            INameScope nameScope;
            ElementSpy elementSpy = args.NewValue as ElementSpy;
    
            if (elementSpy != null && elementSpy.Element != null)
            {
                nameScope = NameScope.GetNameScope(elementSpy.Element);
                if (nameScope != null)
                {
                    d.Dispatcher.BeginInvoke(new Action<DependencyObject, INameScope>(SetScope),
                        System.Windows.Threading.DispatcherPriority.Normal,
                        d, nameScope);
                }
            }
        }
    
        private static void SetScope(DependencyObject d, INameScope nameScope)
        {
            NameScope.SetNameScope(d, nameScope);
        }
     
        public DependencyObject Element
        {
            get
            {
                if (element == null)
                {
                    PropertyInfo propertyInfo = typeof(Freezable).GetProperty("InheritanceContext",
                        BindingFlags.NonPublic | BindingFlags.Instance);
    
                    element = propertyInfo.GetValue(this, null) as DependencyObject;
    
                    if (element != null)
                    {
                        Freeze();
                    }
                }
    
                return element;
            }
        }
    
        protected override Freezable CreateInstanceCore()
        {
            return new ElementSpy();
        }
    }
