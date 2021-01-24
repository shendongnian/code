     <telerik:GridViewDataColumn DataMemberBinding="{Binding Direction,Convertor={StaticResource InttoDateConverter }" UniqueName= "Direction" Header="Direction" Width="85" TextAlignment="Left"  HeaderTextAlignment="Center" DisplayIndex="9" IsFilteringDeferred="True" >
    
    
    public class InttoDateConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, 
                    System.Globalization.CultureInfo culture)
            {
                switch (value.ToString().ToLower())
                {
                    case "0":
                        return "Error!";
                    case "1":
                        return "Forward";
    
                    default:
                        return "Reverse";
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, 
                    System.Globalization.CultureInfo culture)
            {
               // only for two way binding
            }
        }
