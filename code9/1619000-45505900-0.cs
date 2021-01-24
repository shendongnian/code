    <TabControl ItemsSource="{Binding MyTabItems}">
                <TabControl.ContentTemplate>
    				<DataTemplate>
                        <ContentControl Content="{Binding}"/>
    				</DataTemplate>
                </TabControl.ContentTemplate>
    </TabControl>
