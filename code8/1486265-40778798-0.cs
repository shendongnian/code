    <ListBox
        HorizontalContentAlignment="Stretch"
        ItemsSource="{Binding timeline.groups}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <DockPanel LastChildFill="True">
                            <ItemsControl ItemsSource="{Binding tracks}">
                                <ItemsControl.ItemTemplate >
                                    <ItemsControl ItemsSource="{Binding units}">
                                        <ItemsControl.ItemTemplate >
                                        </ItemsControl.ItemTemplate >
                                    </ItemsControl>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </DockPanel>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
