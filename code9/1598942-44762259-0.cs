    public class ResourceConverter : DependencyObject, IValueConverter
    {
        public static readonly DependencyProperty ParentWindowProperty =
             DependencyProperty.Register("ParentWindow", typeof(Window), typeof(ResourceConverter));
        public Window ParentWindow
        {
            get { return (Window)GetValue(ParentWindowProperty); }
            set { SetValue(ParentWindowProperty, value); }
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceKey = value as string;
            if (ParentWindow == null || resourceKey == null)
                return value;
            return ParentWindow.Resources[resourceKey];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
----------
    <Window ... x:Name="win>
        <Window.Resources>
            <BitmapImage x:Key="test-icon" UriSource="Resources/testicon.png" />
        </Window.Resources>
    ...
    <DataGrid ItemsSource="{Binding}">
        <DataGrid.Resources>
            <local:ResourceConverter x:Key="ResourceConverter"
                                     ParentWindow="{Binding Source={x:Reference win}}" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Fill" Width="1*" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Image Source="{Binding Path=fill, Converter={StaticResource ResourceConverter}}"
                                       Width="15px" Height="15px"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
