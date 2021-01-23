    <Border>
        <Border.Style>
            <Style TargetType="Border">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu Name="switchContextMenu">
                            <MenuItem Name="miOpen" Header="{Binding Path=Resources.PowerControlSystem_OPEN, Source={StaticResource LocalizedStrings} }" 
                                Click="miOpen_Click">
                                <MenuItem.Visibility>
                                    <MultiBinding Converter="{StaticResource BooleanToVisibilityMultiValueAND}">
                                        <Binding Path="OpenAvailable" />
                                        <Binding Path="OpenVisible" />
                                    </MultiBinding>
                                </MenuItem.Visibility>
                            </MenuItem>
                            <MenuItem Name="miClose" Header="{Binding Path=Resources.PowerControlSystem_CLOSE, Source={StaticResource LocalizedStrings} }" 
                                Click="miClose_Click">
                                <MenuItem.Visibility>
                                    <MultiBinding Converter="{StaticResource BooleanToVisibilityMultiValueAND}">
                                        <Binding Path="CloseAvailable" />
                                        <Binding Path="CloseVisible" />
                                    </MultiBinding>
                                </MenuItem.Visibility>
                            </MenuItem>
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Value="False">
                        <DataTrigger.Binding>
                            <MultiBinding Converter="{StaticResource ContextMenuBoolAggregate}">
                                <Binding Path="OpenAvailable" />
                                <Binding Path="OpenVisible" />
                                <Binding Path="CloseAvailable" />
                                <Binding Path="CloseVisible" />
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="ContextMenu" Value="{x:Null}"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Border.Style>
    </Border>
