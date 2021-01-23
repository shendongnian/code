    public static class ValidationHelper
    {
        public static bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }
        public static bool ShowValidHint(DependencyObject dependencyObject)
        {
            if (IsValid(dependencyObject)) return true;
            MessageBox.Show(Strings.WarningInput, Strings.InputError, MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
    }
