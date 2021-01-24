    <ListView x:Name="listview" xmlns:local="clr-namespace:WpfApplication1">
        <ListView.Resources>
            <local:ImageConverter x:Key="ImageConverter" />
        </ListView.Resources>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Image">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Image Source="{Binding Path=., Converter={StaticResource ImageConverter}}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn DisplayMemberBinding="{Binding Vorname}" Header="Vorname" />
                <GridViewColumn DisplayMemberBinding="{Binding Nachname}" Header="Nachname" />
                <GridViewColumn DisplayMemberBinding="{Binding Postleitzahl}" Header="PLZ" />
                <GridViewColumn DisplayMemberBinding="{Binding Ort}" Header="Ort" />
                <GridViewColumn DisplayMemberBinding="{Binding Land}" Header="Land" />
            </GridView>
        </ListView.View>
    </ListView>
----------
    namespace WpfApplication1
    {
        public class ImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                dynamic dataObject = value;
                if (dataObject != null)
                {
                    string path = dataObject.GetGuestImage();
                    if(System.IO.File.Exists(path))
                        return new Uri(dataObject.GetGuestImage(), UriKind.RelativeOrAbsolute);
                }
                return new Uri(@"c:\yourplaceholderimage.png", UriKind.RelativeOrAbsolute);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
