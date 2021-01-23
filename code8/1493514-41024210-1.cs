    <DataGridTextColumn Header="Status" Binding="{Binding AddColumnStatus, UpdateSourceTrigger=LostFocus}" Width="Auto" IsReadOnly="True">
                <DataGridTextColumn.CellStyle>
                      <Style TargetType="DataGridCell">
                            <Setter Property="Background" Value="Yellow" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding AddColumnStatus}" Value="YourStatusA">
                                    <Setter Property="Background" Value="Green" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding AddColumnStatus}" Value="YourStatusB">
                                    <Setter Property="Background" Value="Red" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
