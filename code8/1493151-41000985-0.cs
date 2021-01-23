         <ItemsControl ItemsSource="{Binding VehCollection}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="39.8" />
                            <ColumnDefinition Width="39.8" />
                            <ColumnDefinition Width="80"  />
                            <ColumnDefinition Width="80" />
                        </Grid.ColumnDefinitions>
                        <StackPanel Orientation="Horizontal" Grid.Column="{Binding Column}">
                            <TextBox Text="{Binding Alt}" />
                            <TextBox Text="{Binding Depth}" />
                        </StackPanel>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
