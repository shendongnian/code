    <DataGrid>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="ID" Width="50" CanUserSort="False">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <TextBox Name="txtID" Text="{Binding ID, UpdateSourceTrigger=PropertyChanged}" HorizontalAlignment="Stretch" MaxLength="20" />
                            <TextBox Name="txtArrow" Text="&#x21E8;" HorizontalAlignment="Stretch">
                                <TextBox.Visibility>
                                    <Binding Path="IsSelected" RelativeSource="{RelativeSource AncestorType=DataGridRow}">
                                        <Binding.Converter>
                                            <BooleanToVisibilityConverter/>
                                        </Binding.Converter>
                                    </Binding>
                                </TextBox.Visibility>
                            </TextBox>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
