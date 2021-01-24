    <TabControl>
        <TabItem Header="ERP">
            <ContentControl Name="ccERP" Background="#FFE5E5E5" 
                                    Content="{Binding DataContext.SelectedConnection.ERP.PluginInstance.UI, RelativeSource={RelativeSource AncestorType=Window}}"/>
        </TabItem>
    </TabControl>
