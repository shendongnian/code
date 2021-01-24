    <TreeView.Resources>
        ...
        <ContextMenu x:Key="SceneLevel">
            <MenuItem Header="Add selected character" Command="{Binding Path=DataContext.AddSelectedCharacter, Source={x:Reference ScenesTreeView01}}"/>
        </ContextMenu>
        ...
    </TreeView.Resources>
