    <ListView ItemsSource="{Binding Items}" IsItemClickEnabled="True" ItemClick="ListView_ItemClick" Margin="0,50,0,0" >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding ItemQuantity}" />
                </DataTemplate>
            </ListView.ItemTemplate>
    </ListView>
