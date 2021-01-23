    <DataGridComboBoxColumn  Header="Status" Width="auto"  IsReadOnly="False"  >
                    <DataGridColumn.HeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="Background" Value="LightGoldenrodYellow" />
                            <Setter Property="BorderThickness" Value="2,2,0,2" />
                        </Style>
                    </DataGridColumn.HeaderStyle>
                    <DataGridComboBoxColumn.ItemsSource>
                        <CompositeCollection>
                            <sys:String>Not Started</sys:String>
                            <sys:String>In Progress</sys:String>
                            <sys:String>Completed</sys:String>
                        </CompositeCollection>
                    </DataGridComboBoxColumn.ItemsSource>
                </DataGridComboBoxColumn>
