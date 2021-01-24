    public class DataItem
    {
        public bool IsEnabled { get; set; }
    }
    ...
    public MainWindow()
    {
        InitializeComponent();
        MyListView123.ItemsSource = new List<DataItem>
        {
            new DataItem() { IsEnabled = true }, new DataItem() { IsEnabled = false }, new DataItem() { IsEnabled = true }
        };
    }
----------
    <ListView Name="MyListView123">
        <ListView.Resources>
            <BooleanToVisibilityConverter x:Key="BoolToVisibility" />
        </ListView.Resources>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="Visibility" Value="{Binding Path=IsEnabled, Converter={StaticResource BoolToVisibility}}"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn DisplayMemberBinding="{Binding IsEnabled}" />
            </GridView>
        </ListView.View>
    </ListView>
