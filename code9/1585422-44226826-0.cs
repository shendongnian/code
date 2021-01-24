    public class MyVisibilityValueConverter : MvxBaseVisibilityValueConverter<bool>
    {
        protected override MvxVisibility Convert(string value, object parameter, CultureInfo culture)
        {
            return (value ==true) ? MvxVisibility.Visible : MvxVisibility.Collapsed;
        }
    }
