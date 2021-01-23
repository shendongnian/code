      <DataGrid x:Name="Dgrd">
            <DataGrid.CellStyle>
                <Style TargetType="DataGridCell">
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Status}" Value="0"/>
                                <Condition Binding="{Binding Column.DisplayIndex,RelativeSource={RelativeSource Self}}" Value="1"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="Blue"/>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Status}" Value="1"/>
                                <Condition Binding="{Binding Column.DisplayIndex,RelativeSource={RelativeSource Self}}" Value="1"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="Red"/>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Status}" Value="2"/>
                                <Condition Binding="{Binding Column.DisplayIndex,RelativeSource={RelativeSource Self}}" Value="1"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="Yellow"/>
                        </MultiDataTrigger>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding Status}" Value="3"/>
                                <Condition Binding="{Binding Column.DisplayIndex,RelativeSource={RelativeSource Self}}" Value="1"/>
                            </MultiDataTrigger.Conditions>
                            <Setter Property="Background" Value="Olive"/>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </DataGrid.CellStyle>
        </DataGrid>
