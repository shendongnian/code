    You can achieve your requirement by using IValueConverter.
    
        <ContentPage.Resources>
            <ResourceDictionary>
                <local:Class1 x:Key="class1" />
            </ResourceDictionary>
        </ContentPage.Resources>
    
    <ListView x:Name="lstData">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{Binding OrderId}" TextColor="{Binding Colors, Converter={StaticResource class1}}" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    
    //Converter class
    
        public class Class1 : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if ((int)value > 1000)
                    return Color.Green;
                else
                    return Color.Red;
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
