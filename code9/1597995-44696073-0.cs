    public class OddConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;
            return (int)value % 2 != 0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
----------
    <DataGrid ItemsSource="{Binding MyDataTable}" AutoGenerateColumns="True" />
        <DataGrid.Resources>
            <local:OddConverter x:Key="oddConverter" />
            <Style TargetType="{x:Type DataGridCell}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=Column.DisplayIndex,RelativeSource={RelativeSource Self},Converter={StaticResource oddConverter}}" Value="True">
                        <Setter Property="Background" Value="Silver"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
