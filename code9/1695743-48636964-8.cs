    <TabControl Margin="10,10,10,40" ItemsSource="{Binding Test}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <GeneralTab TabName="{Binding Name}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
