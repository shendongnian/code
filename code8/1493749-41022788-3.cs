    public class MainCategoryModel
    {
        public ObservableCollection<PageInput> myList { get; set; }
        public MainCategoryModel()
        {
            myList = new ObservableCollection<PageInput>();
        }
        public void AddShow(PageInput show)
        {
            myList.Insert(0, show);
        }
        public void Clear()
        {
            myList.Clear();
        }
    }
    <Page>
    (........)
        <GridView x:Name="lvListSource" ItemsSource="{x:Bind model.myList, Mode=OneWay}" SelectedIndex="-1" Grid.Row="2" HorizontalContentAlignment="Center">
        <GridView.ItemTemplate>
            <DataTemplate x:DataType="local:PageInput">
                <TextBlock Name="AlbumBlock" Foreground="Black" FontWeight="Normal" FontSize="15" Margin="5,0,5,0"
                                    Text="{x:Bind Name}" HorizontalAlignment="Left" VerticalAlignment="Center" Width="100"/>
            </DataTemplate>
        </GridView.ItemTemplate>
    </GridView>
