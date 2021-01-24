    // Move to a parent that can take the focus
    FrameworkElement parent = (FrameworkElement)yourElement.Parent;
    while (parent != null && parent is IInputElement && ! ((IInputElement)parent).Focusable)
    {
        parent = (FrameworkElement)parent.Parent;
    }
    DependencyObject scope = FocusManager.GetFocusScope(yourElement);
    FocusManager.SetFocusedElement(scope, parent as IInputElement);
