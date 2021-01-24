        <DataGrid ItemsSource="{Binding DataObjectCollection}" SelectedItem="{Binding SelectedItem}" MinHeight="200">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock.Text>
                                    <PriorityBinding>
                                        <Binding Path="Object1" Converter="{StaticResource EmptyStringToDependencyPropertyUnset}"/>
                                        <Binding Path="Object2"/>
                                    </PriorityBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
