    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <ItemsControl ItemsSource="{Binding}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBox Text="{Binding Path=ShippingLabel, Mode=OneWay}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
        <ItemsControl ItemsSource="{Binding}" Grid.Column="2">
            <ItemsControl.Resources>
                <local:ShippingLabelConverter x:Key="labelConverter" />
            </ItemsControl.Resources>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBox Text="{Binding Converter={StaticResource labelConverter},Mode=OneWay}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
