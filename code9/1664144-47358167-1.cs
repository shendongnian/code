    <DataGrid ItemsSource="{Binding Collection1}" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Field1" Binding="{Binding Field1}"></DataGridTextColumn>
                    <DataGridTextColumn Header="Field2" Binding="{Binding Field2}"></DataGridTextColumn>
                    <DataGridCheckBoxColumn Header="Field3" Binding="{Binding Field3}"></DataGridCheckBoxColumn>
                    <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="{Binding Field3, Converter={StaticResource boolToUriConverter}}"/>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
     
