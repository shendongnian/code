    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        <ListView x:Name="OrdersListView" IsItemClickEnabled="True" SelectionMode="Single"
                    ItemClick="OrdersListView_ItemClick"  SelectedItem="{Binding AllRoundsSelectedItem, Mode=TwoWay}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding ItemName}" />
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <ListView x:Name="DetailsListView" ItemsSource="{Binding AllRoundsSelectedItem}" Grid.Column="1">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding}" FontSize="20" />
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
