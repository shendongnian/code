    <ItemsPresenter Tag="{Binding RelativeSource={RelativeSource AncestorType=DataGrid}}">
        <ItemsPresenter.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Insert2" InputGestureText="Ctrl+I"
                            DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                            Command="{Binding DataContext.InsertSelectedItems}"
                            CommandParameter="{Binding SelectedIndex}"/>
                <MenuItem Header="Remove2" InputGestureText="Ctrl+D"
                            DataContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                            Command="{Binding DataContext.RemoveSelectedItems}"
                            CommandParameter="{Binding SelectedItems}"/>
            </ContextMenu>
        </ItemsPresenter.ContextMenu>
    </ItemsPresenter>
