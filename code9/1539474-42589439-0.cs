    namespace WpfApplication1
    {
        
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return (value as DataGridRow).GetIndex();
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
----------
    <Style x:Key="DefaultDataGridCell" TargetType="{x:Type DataGridCell}"
                   xmlns:local="clr-namespace:WpfApplication1">
        <Style.Resources>
            <local:MyConverter x:Key="conv" />
        </Style.Resources>
        <Setter Property="IsTabStop" Value="False" />
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=Column.DisplayIndex}" Value="0" />
                    <Condition Binding="{Binding RelativeSource={RelativeSource AncestorType=DataGridRow}, Converter={StaticResource conv}}" Value="0" />
                </MultiDataTrigger.Conditions>
                <Setter Property="IsTabStop" Value="True" />
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
