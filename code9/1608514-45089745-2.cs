    <DataGrid 
        >
        <DataGrid.Resources>
            <local:BindingProxy
                x:Key="UserControlBindingProxy"
                Data="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}"
                />
        </DataGrid.Resources>
        <DataGrid.ContextMenu>
            <ContextMenu 
                IsEnabled="{Binding Data.UseContextMenu, Source={StaticResource UserControlBindingProxy}}"
                >
                <MenuItem Header="Test Item" />
                <MenuItem Header="Test Item" />
                <MenuItem Header="Test Item" />
                <MenuItem Header="Test Item" />
            </ContextMenu>
        </DataGrid.ContextMenu>
    </DataGrid>
