    <ContentControl Name="ccERP" Background="#FFE5E5E5" 
                            Content="{Binding ElementName=lbVerbindungen, Path=SelectedItem.ERP.PluginInstance}">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type local:IPlugin}">
                <local:PluginUserControl />
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
