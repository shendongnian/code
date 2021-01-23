    <ListBox HorizontalContentAlignment="Stretch"
                 Name="list"
                 ItemsSource="{Binding groups}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <DockPanel LastChildFill="True">
                        <ItemsControl ItemsSource="{Binding tracks}">
                            <ItemsControl.ItemTemplate >
                                <DataTemplate>
                                    <ItemsControl ItemsSource="{Binding units}">
                                        <ItemsControl.ItemTemplate>
                                            <DataTemplate>
                                                <TextBox Text="{Binding unitName}"/>
                                            </DataTemplate>
                                        </ItemsControl.ItemTemplate>
                                    </ItemsControl>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </DockPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
