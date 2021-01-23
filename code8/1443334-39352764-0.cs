    public class ElementPermissionToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Dictionary<string, Action> permissions = values.OfType<Dictionary<string, Action>>().FirstOrDefault();
            FrameworkElement element = values.OfType<FrameworkElement>().FirstOrDefault();
    
            if (permissions != null && element != null && !string.IsNullOrWhiteSpace(element.Name))
            {
                Action action;
    
                if (permissions.TryGetValue(element.Name, out action))
                {
                    return action.CanBeShown ? Visibility.Visible : Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
