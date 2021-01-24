    <StackPanel>
        <ListView ItemsSource="{Binding Items}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="100" />
                            <ColumnDefinition Width="100" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0"
                                   Text="{Binding First}" />
                        <TextBlock Grid.Column="1"
                                   Text="{Binding Second}" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Button Command="{Binding DoSomethingCommand}"
                Content="Do something" />
    </StackPanel>
