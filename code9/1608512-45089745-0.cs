    <DataGrid 
        >
        <DataGrid.Style>
            <Style TargetType="DataGrid" BasedOn="{StaticResource {x:Type DataGrid}}">
                <Style.Triggers>
                    <DataTrigger 
                        Binding="{Binding UseContextMenu, RelativeSource={RelativeSource AncestorType=UserControl}}"
                        Value="True"
                        >
                        <Setter Property="ContextMenu">
                            <Setter.Value>
                                <ContextMenu 
                                    >
                                    <MenuItem Header="Test Item" />
                                    <MenuItem Header="Test Item" />
                                    <MenuItem Header="Test Item" />
                                    <MenuItem Header="Test Item" />
                                </ContextMenu>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.Style>
    </DataGrid>
