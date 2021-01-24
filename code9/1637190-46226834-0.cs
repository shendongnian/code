    <TabControl ItemsSource="{Binding Tabs}" SelectedIndex="{Binding Selected}">
        <TabControl.ContentTemplate>
            <DataTemplate>
                <localviews:PersonMainPanel />
            </DataTemplate>
        </TabControl.ContentTemplate>
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding Header}"/>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
