    public class StakPanelToVisible : IValueConverter
    {
         // public static bool StackPanelVis; // remove this one
         public object Convert(object value, Type targetType, object parameter,
                          System.Globalization.CultureInfo culture)
         { 
              // value = StackPanelVis; // and this one
              return (bool)value ? Visibility.Visible : Visibility.Collapsed;
         }
         public object ConvertBack(...) {empty}
    }
