    <ContextMenu x:Key="CharacterMenu" ItemsSource="{Binding SceneAddMenu}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Header" Value="{Binding Displayname}" />
                <Setter Property="Command" Value="{Binding ContextMenuCommand} " />
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
