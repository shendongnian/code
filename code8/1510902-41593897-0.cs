    <ListView x:Name="lv">
        <ListView.Resources>
            <local:TheConverter x:Key="TheConverter" />
        </ListView.Resources>
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Style.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource TheConverter}">
                                <Binding Path="." />
                                <Binding Path="DataContext.TheOtherCollectionProperty" RelativeSource="{RelativeSource AncestorType=ListView}" />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Background" Value="Red" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding Name}" />
            </GridView>
        </ListView.View>
    </ListView>
----------
    public class TheConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return false;
            YourDataObject obj = values[0] as YourDataObject;
            System.Collections.IList collection = values[1] as System.Collections.IList;
            return collection != null && collection.Contains(obj);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
