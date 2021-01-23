    private bool IsValid(DependencyObject obj)
    {
        return !Validation.GetHasError(obj) && LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>().All(IsValid);
        yourProperty = value;
    }
