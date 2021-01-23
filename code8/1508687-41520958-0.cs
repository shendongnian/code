    <ListBox x:Name="listBox" ItemsSource="{Binding}" DataContext="{StaticResource itemsViewSource}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Expander x:Name="expander" Header="{Binding name}">
                    <ListBox DisplayMemberPath="name" Loaded="ListBox_Loaded" />
                </Expander>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
----------
    private void ListBox_Loaded(object sender, RoutedEventArgs e)
    {
        ListBox inner = sender as ListBox;
        if (inner != null)
        {
            DataRowView drv = inner.DataContext as DataRowView;
            if (drv != null)
            {
                DataView childView = drv.CreateChildView(drv.DataView.Table.ChildRelations[0]);
                //or drv.CreateChildView(drv.DataView.Table.ChildRelations["FK_options_items"]);
                inner.ItemsSource = childView;
            }
        }
    }
