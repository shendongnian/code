    <Page.Resources>
        <local:ImageURIConverter x:Key="ImageURIConverter" />
    </Page.Resources>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView IsItemClickEnabled="True" ItemClick="ListView_ItemClick" ItemsSource="{x:Bind ImageList}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ViewModel">
                    <Image Height="200" Source="{x:Bind ImageURI, Converter={StaticResource ImageURIConverter}, Mode=OneWay}" />
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid> 
