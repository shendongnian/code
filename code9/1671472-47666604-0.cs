    <Grid>
        <Grid.Resources>
            <ResourceDictionary>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="AllowDrop" Value="{Binding AllowDrop}"/>
                </Style>
            </ResourceDictionary>
        </Grid.Resources>
        <TreeView ItemsSource="{Binding MyItems}">
            <TreeView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBlock Text="{Binding Id}"/>
                        <TextBlock Margin="5,0" Text="{Binding AllowDrop}"/>
                    </StackPanel>
                </DataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
    </Grid>
