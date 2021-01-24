    <Style TargetType="ListBoxItem">
        <Setter Property="Tag" Value="{Binding DataContext, RelativeSource={RelativeSource AncestorType=ListBox}}" />
        <Setter Property="ContextMenu">
            <Setter.Value>
                <ContextMenu>
                    <MenuItem Command="{Binding PlacementTarget.Tag.OpenWatchFolder,
                                        RelativeSource={RelativeSource AncestorType=ContextMenu}}" Header="Open" FontWeight="Bold">
                        <MenuItem.Icon>
                            <Image Source="/Tornado Player;component/Images/Folder Open.png"/>
                        </MenuItem.Icon>
                    </MenuItem>
                    <Separator/>
                    <MenuItem Command="{Binding PlacementTarget.Tag.DeleteWatchFolder, 
                                        RelativeSource={RelativeSource AncestorType=ContextMenu}}" Header="Remove">
                        <MenuItem.Icon>
                            <Image Source="/Tornado Player;component/Images/Delete.png"/>
                        </MenuItem.Icon>
                    </MenuItem>
                </ContextMenu>
            </Setter.Value>
        </Setter>
    </Style>
