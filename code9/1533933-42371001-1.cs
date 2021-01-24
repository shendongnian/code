    public class DataGridConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty SourceCollectionProperty =
             DependencyProperty.Register("SourceCollection", typeof(IEnumerable),
             typeof(DataGridConverter), new FrameworkPropertyMetadata(null));
        public IEnumerable SourceCollection
        {
            get { return (IEnumerable)GetValue(SourceCollectionProperty); }
            set { SetValue(SourceCollectionProperty, value); }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
----------
    <DataGrid ItemsSource="{Binding TableItems}" Name="TableDataGrid" AutoGenerateColumns="False" BorderThickness="0">
        <DataGrid.Resources>
            <local:DataGridConverter x:Key="converter" SourceCollection="{Binding Path=DataContext.TableItems, Source={x:Reference TableDataGrid}}" />
        </DataGrid.Resources>
        <DataGrid.ItemContainerStyle>
            <Style TargetType="DataGridRow">
                <Setter Property="BorderBrush" Value="#FF9E9E9E"/>
                <Setter Property="BorderThickness" Value="{Binding Path=., Converter={StaticResource converter}}"/>
            </Style>
        </DataGrid.ItemContainerStyle>
    </DataGrid>
