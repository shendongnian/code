    namespace WpfApplication1
    {
        public class ColorConverter : IValueConverter
        {
            private static List<System.Windows.Media.Brush> _brushesToChooseFrom = new List<System.Windows.Media.Brush>()
            {
                System.Windows.Media.Brushes.Green,
                System.Windows.Media.Brushes.Red,
                System.Windows.Media.Brushes.Violet,
                System.Windows.Media.Brushes.Yellow
            };
            private Dictionary<int, System.Windows.Media.Brush> _usedBrushes = new Dictionary<int, System.Windows.Media.Brush>();
            private int index = 0;
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int col2 = (int)value;
                if(!_usedBrushes.ContainsKey(col2))
                {
                    System.Windows.Media.Brush brush = _brushesToChooseFrom[index++];
                    if (index == _brushesToChooseFrom.Count)
                        index = 0;
                    _usedBrushes.Add(col2, brush);
                }
                return _usedBrushes[col2];
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
----------
    <ListView x:Name="Zebra"
                  ItemsSource="{Binding Path=obsListItems}"
                  SelectionMode="Single" Background="#FFC8F0F1" FontSize="16" Margin="0,0,0,10"
                  xmlns:local="clr-namespace:WpfApplication1">
        <ListView.Resources>
            <local:ColorConverter x:Key="conv" />
        </ListView.Resources>
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="Background" Value="{Binding col2, Converter={StaticResource conv}}" />
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Column 1"
                                            DisplayMemberBinding="{Binding col1}"
                                            Width="70" />
                <GridViewColumn Header="Column 2"
                                            DisplayMemberBinding="{Binding col2}"
                                            Width="90" />
            </GridView>
        </ListView.View>
    </ListView>
