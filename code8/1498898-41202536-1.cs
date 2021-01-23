    <TabControl x:Name="Tabs">
        <TabControl.ContentTemplate>
            <DataTemplate>
                <StackPanel>
                    <DataGrid ItemsSource="{Binding DefaultView}" />
                </StackPanel>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
