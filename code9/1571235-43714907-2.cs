    <ListView Name="MyListView" ItemClick="ListView_ItemClick" IsItemClickEnabled="True">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding }"></TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
