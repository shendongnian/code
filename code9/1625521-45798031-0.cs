    <StackPanel Orientation="Horizontal">
        <TextBlock Text="{Binding Name}" Tag="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}">
            <TextBlock.ContextMenu>
                <ContextMenu>
                    <ContextMenu.ItemContainerStyle>
                        <Style TargetType="MenuItem">
                            <Setter Property="Command" Value="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ContextMenu}}, Path=PlacementTarget.Tag.DataContext.EditCmd}"/>
                        </Style>
                    </ContextMenu.ItemContainerStyle>
                </ContextMenu>
            </TextBlock.ContextMenu>
        </TextBlock>
    </StackPanel>
