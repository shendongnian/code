    <Menu DockPanel.Dock="Top">
        <MenuItem Header="{Binding Menu.Business}" Visibility="{Binding allowUI, Converter={StaticResource BoolToVisConverter} }">
            <MenuItem.Style>
                <Style TargetType="MenuItem" BasedOn="{StaticResource {x:Type MenuItem}}">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Menu.IsEditable}" Value="True">
                            <Setter Property="ContextMenu">
                                <Setter.Value>
                                    <ContextMenu>
                                        <MenuItem>
                                            <MenuItem.Header>
                                                <TextBox Text="{Binding Menu.Business, UpdateSourceTrigger=PropertyChanged}" LostFocus="end_change_UI" />
                                            </MenuItem.Header>
                                        </MenuItem>
                                    </ContextMenu>
                                </Setter.Value>
                            </Setter>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </MenuItem.Style>
        </MenuItem>
    </Menu>
