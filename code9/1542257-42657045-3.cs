    <DataGrid x:Name="dataGrid" xmlns:local="clr-namespace:Wp">
        <DataGrid.Resources>
            <local:Converter x:Key="conv" />
        </DataGrid.Resources>
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <Setter Property="Background">
                    <Setter.Value>
                        <MultiBinding Converter="{StaticResource conv}">
                            <Binding Path="." />
                            <Binding Path="ItemsSource" RelativeSource="{RelativeSource AncestorType=DataGrid}" />
                        </MultiBinding>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.RowStyle>
    </DataGrid>
----------
    namespace WpfApplication1
    {
        public class Converter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                MyDataObject x = values[0] as MyDataObject;
                if(x != null)
                {
                    IEnumerable<MyDataObject> collection = values[1] as IEnumerable<MyDataObject>;
                    if(collection != null && x.TotalCost == collection.Min(y => y.TotalCost))
                        return System.Windows.Media.Brushes.Green;
                }
                return System.Windows.DependencyProperty.UnsetValue;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
