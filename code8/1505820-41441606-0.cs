    <DataGrid ItemsSource="{Binding Peoples}">
        <DataGrid.Resources>
            <ContextMenu x:Key="ctx_menu">
                <ContextMenu.Resources>
                    <Style TargetType="{x:Type MenuItem}">
                        <Setter Property="DataContext" Value="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
                    </Style>
                </ContextMenu.Resources>
                <MenuItem Command="{Binding DataContext.RemoveCommand}"
                          CommandParameter="{Binding PlacementTarget.DataContext, RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}}}"
                          Header="Remove" />
            </ContextMenu>
        </DataGrid.Resources>
        
        <DataGrid.ItemContainerStyle>
            <Style TargetType="{x:Type DataGridRow}">
                <Setter Property="ContextMenu" Value="{StaticResource ctx_menu}" />
            </Style>
        </DataGrid.ItemContainerStyle>
    </DataGrid>
