    <TabControl ItemsSource="{Binding myObservableCollection}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Visibility" Value="Collapsed" />
            </Style>
        </TabControl.ItemContainerStyle>
        <TabControl.ContentTemplate>
            <DataTemplate>
                <TextBlock>content...</TextBlock>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
