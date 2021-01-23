    public static void RemoveFromParent(FrameworkElement child)
    {
        DependencyObject parent = child.Parent;
        if (parent == null)
            return;
        if (parent is Panel)
            ((Panel)parent).Children.Remove(child);
        else if (parent is Decorator)
            ((Decorator)parent).Child = null;
        else if (parent is ContentControl)
            ((ContentControl)parent).Content = null;
        else if (parent is ContentPresenter)
            ((ContentPresenter)parent).Content = null;
        else
            throw new Exception("RemoveFromParent: Unsupported type " + parent.GetType().ToString());
    }
