    <TabControl ItemsSource="{Binding Items}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding Title}" />
            </Style>
        </TabControl.ItemContainerStyle>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <ComboBox ItemsSource="{Binding Foo}" SelectedItem="{Binding SelectedFoo}" />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
