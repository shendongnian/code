    <ItemsControl ItemsSource="{Binding ExtensionGroups}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <Label Content="{Binding Name}"/>
                    <ItemsControl ItemsSource="{Binding ExtensionInfos}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <WrapPanel />
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <CheckBox IsChecked="{Binding IsChecked}"
                                          Content="{Binding Extension}"/>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
