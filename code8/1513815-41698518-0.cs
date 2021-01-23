    <TabControl x:Name="tabControl" Margin="10,10,10,37" ItemsSource="{Binding Groups}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Key}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <WrapPanel />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding ValidationName}" Margin="10"/>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
