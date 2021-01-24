            <TabControl Grid.Row="0" Grid.RowSpan="2" Grid.Column="1"
                ItemsSource="{Binding TabItems}"
                SelectedIndex="{Binding SelectedTabIndex}">
            <TabControl.ItemTemplate>
                <!-- this is the header template-->
                <DataTemplate>
                        <TextBlock
                            Text="{Binding Header}" />                    
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <!-- this is the body of the TabItem template-->
                <DataTemplate>
                    <local:POSSalesDetailsView/>//**Problem is here**
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
