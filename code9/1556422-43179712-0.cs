    <TabControl ItemsSource="{Binding myPersonInfo}" SelectedIndex="0">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Path=Key.Name}"/>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Value.BMI}"/>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
