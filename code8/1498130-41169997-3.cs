    <TabControl ItemsSource="{Binding Items}" behaviors:TabContent.IsCached="True">
        <!-- Make sure that you don't set the TabControl's ContentTemplate property but the custom one here-->
        <behaviors:TabContent.Template>
            <DataTemplate>
                <StackPanel>
                    <TextBox />
                </StackPanel>
            </DataTemplate>
        </behaviors:TabContent.Template>
    </TabControl>
