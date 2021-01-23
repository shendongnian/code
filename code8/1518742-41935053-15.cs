                                <DataGridTextColumn Header="Value" >
                                    <DataGridTextColumn.HeaderStyle>
                                        <Style TargetType="DataGridColumnHeader">
                                            <Setter Property="Width" Value="{Binding ElementName=Test, Path=DataContext.Col1Width, UpdateSourceTrigger=PropertyChanged}"/>
                                        </Style>
                                    </DataGridTextColumn.HeaderStyle>
                                </DataGridTextColumn>
                                <DataGridTextColumn Header="Month" >
                                    <DataGridTextColumn.HeaderStyle>
                                        <Style TargetType="DataGridColumnHeader">
                                            <Setter Property="Width" Value="{Binding ElementName=Test, Path=DataContext.Col2Width, UpdateSourceTrigger=PropertyChanged}"/>
                                        </Style>
                                    </DataGridTextColumn.HeaderStyle>
                                </DataGridTextColumn>
