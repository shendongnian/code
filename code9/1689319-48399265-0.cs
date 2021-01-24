     <TabControl x:Name="tabCases" IsSynchronizedWithCurrentItem="True" Controls:ClosableTabItem.TabClose="TabClosed">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <Controls:MyTabItem >
                    <TextBlock Text="{Binding Path=Id}" />
                </Controls:MyTabItem >
            </DataTemplate>
        </TabControl.ItemTemplate>
        </TabControl>
