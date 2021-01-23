    public class DayToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // logic here
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // logic here
        }
    }
    <DataGridTextColumn Binding="{Binding CurrentDay}">
        <DataGridTextColumn.ElementStyle>
            <Style TargetType="{x:Type TextBlock}">
                <Setter Property="Background" Value="{Binding Name, Converter={StaticResource DayToBackgroundConverter }}"/>
            </Style>
        </DataGridTextColumn.ElementStyle>
    </DataGridTextColumn>
