    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListView x:Name="ListView1" Grid.Column="0" 
                  ItemsSource="{Binding MyObjectCollection}">
            <ListView.ItemTemplate>
                <Datatemplate>
                    <TextBlock Text="{Binding ObjectName}"/>
                </Datatemplate
            </ListView.ItemTemplate>
        </ListView>
        <Grid Grid.Column=1 DataContext="{Binding ElementName=ListView1, Path=SelectedItem}"> 
            <ListView ItemsSource="{Binding AnotherObjectCollection}"/>
        </Grid>
    </Grid>
