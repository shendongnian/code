    <TextBlock Text="{Binding Name}" Grid.Column="0" Tag="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=TreeView}}">
        <TextBlock.ContextMenu>
            <ContextMenu Tag="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                <MenuItem Header="Delete Document" ToolTip="{Binding Name}" 
                                                      Command="{Binding PlacementTarget.Tag.DataContext.PCommand, 
                                                                RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"    
                                                      CommandParameter="{Binding Name}" />
            </ContextMenu>
        </TextBlock.ContextMenu>
    </TextBlock>
