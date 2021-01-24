    public class ValueTupleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tuple = value as (string name, string path)?;
    
            if (tuple == null)
                return null;
    
            return tuple.Value.Name;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
    
    <ComboBox x:Name="DatabasesFromDisk">
      <ComboBox.ItemTemplate>
        <DataTemplate>
          <TextBlock Text="{Binding Converter={StaticResource ValueTupleConverter}}"/>
        </DataTemplate>
      </ComboBox.ItemTemplate>
    </ComboBox>
