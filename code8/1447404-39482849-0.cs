     <Menu>
            <MenuItem>
                <MenuItem.Header>
                    <TextBox Text="{Binding ElementName=ItemsControl, Path=Items.Count,  Mode=OneWay}" />
                </MenuItem.Header>
                <ItemsControl x:Name="ItemsControl"
                              ItemsSource="{Binding Items}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal"
                                        Margin="2"
                                        MinWidth="100">
                                <TextBlock Text="{Binding Value.Text}" />
                            </StackPanel>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </MenuItem>
        </Menu>
