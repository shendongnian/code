    ...
    <local:MyBkColorConverter2 x:Key="bkColorCvrt2"/>
    ...
                  <DataGridTextColumn Binding="{Binding c2}" Width="80" Header="c2">
                        <DataGridTextColumn.HeaderStyle>
                            <Style TargetType="{x:Type DataGridColumnHeader}">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <SolidColorBrush Color="Yellow"/>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridTextColumn.HeaderStyle>
                        <DataGridTextColumn.CellStyle>
                            <Style TargetType="{x:Type DataGridCell}">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <Binding Converter="{StaticResource bkColorCvrt2}"/>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridTextColumn.CellStyle>
                    </DataGridTextColumn>
