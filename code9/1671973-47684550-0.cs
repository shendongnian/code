    <Grid>
        <TreeView HorizontalContentAlignment="Stretch">
            <TreeViewItem Header="Level 1" IsExpanded="True" ContextMenuOpening="OnContextMenuOpening">
                <TreeViewItem.ContextMenu>
                    <ContextMenu>
                        <ContextMenu.ItemContainerStyle>
                            <Style TargetType="{x:Type MenuItem}">
                                <Setter Property="Header" Value="{Binding Name}"></Setter>
                                <Setter Property="Command" Value="{Binding}" />
                                <Setter Property="Background" Value="Blue"></Setter>
                                <Setter Property="ItemsSource" Value="{Binding Commands}"></Setter>
                            </Style>
                        </ContextMenu.ItemContainerStyle>
                    </ContextMenu>
                </TreeViewItem.ContextMenu>
            </TreeViewItem>
        </TreeView>
    </Grid>
