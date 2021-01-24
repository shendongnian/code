    <DataGrid AutoGenerateColumns="False" Name="dgHaupt" IsReadOnly="True">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Test" Width="150">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock>
                            <Run>
                                <Run.Style>
                                    <Style TargetType="Run">
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding Test}" Value="7">
                                                <Setter Property="Text" Value="Text" />
                                                <Setter Property="FontStyle" Value="Italic" />
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Run.Style>
                            </Run>
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
