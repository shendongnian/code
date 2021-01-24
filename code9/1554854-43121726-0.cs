    <MenuItem x:Name="UndoProcessMenuITem" Header="Undo Process" Click="UndoProcessMenuITem_Click" >
        <MenuItem.Visibility>
            <MultiBinding Converter="{StaticResource RowUndoButtonVisibility}">
                <Binding Path="{Binding PlacementTarget.DataContext.ProductIsStandby, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                <Binding Path="{Binding PlacementTarget.DataContext.ProductIsDone, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
            </MultiBinding>
        </MenuItem.Visibility>
    </MenuItem>
