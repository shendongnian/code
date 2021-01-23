    public static FrameworkElement GetParentContext(FrameworkElement element) {
        object result = null;
        DependencyObject parent = VisualTreeHelper.GetParent(element);
        FrameworkElement parentElement = parent as FrameworkElement;
        if(null != parentElement) {
            result = parentElement.DataContext;
        }
        return result;        
    }
