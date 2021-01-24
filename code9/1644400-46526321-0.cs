    <ContextMenu>
        <ContextMenu.Resources>
            ...
            <local:Converter x:Key="conv" />
        </ContextMenu.Resources>
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Icon" Value="{Binding Path=., Converter={StaticResource conv}}" />
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
----------
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            File file = value as File;
            if (file != null)
                return file.IconGeometry;
            Record record = value as Record;
            if (record != null)
                return record.RecordIconGeometry;
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
