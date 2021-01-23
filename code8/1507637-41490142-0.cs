    <Style TargetType="{x:Type local:Gadget}" xmlns:s="clr-namespace:System;assembly=mscorlib">
        <Setter Property="Padding" Value="2" />
        <Setter Property="Template" Value="{StaticResource Base}"></Setter>
        <Style.Triggers>
            <DataTrigger Binding="{Binding Content, RelativeSource={RelativeSource Self}, Converter={StaticResource DataTypeConverter}}" 
                         Value="{x:Type s:String}">
                <Setter Property="Template" Value="{StaticResource String}"></Setter>
            </DataTrigger>
            <DataTrigger Binding="{Binding Content, RelativeSource={RelativeSource Self}, Converter={StaticResource DataTypeConverter}}" 
                         Value="{x:Type s:Int32}">
                <Setter Property="Template" Value="{StaticResource Int32}"></Setter>
            </DataTrigger>
        </Style.Triggers>
    </Style>
----------
    public class DTC : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
