    <DataGridComboBoxColumn  Header="Status" Width="auto"  IsReadOnly="False"  >
        <DataGridColumn.HeaderStyle>
            <Style TargetType="DataGridColumnHeader">
                <Setter Property="Background" Value="LightGoldenrodYellow" />
                <Setter Property="BorderThickness" Value="2,2,0,2" />
            </Style>
        </DataGridColumn.HeaderStyle>
        <DataGridComboBoxColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <Setter Property="ContextMenu">
                    <Setter.Value>
                        <ContextMenu>
                            <MenuItem Header="Not Started" />
                            <MenuItem Header="In Progress"  />
                            <MenuItem Header="Completed" />
                        </ContextMenu>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGridComboBoxColumn.CellStyle>
    </DataGridComboBoxColumn>
