            <DataGrid x:Name="quizDatagrid" CanUserAddRows="False" Margin="10,90,0,10" 
                  ClipboardCopyMode="None" AutoGenerateColumns="False" HorizontalAlignment="Left" Width="698">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding id}" Header="Category ID" />
                <DataGridTextColumn Binding="{Binding name}" Header="Category Name" />
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <DataGrid ItemsSource="{Binding question}" AutoGenerateColumns="False">
                                <DataGrid.Columns>
                                    <DataGridTextColumn Binding="{Binding id}" Header="Question ID" />
                                    <DataGridTextColumn Binding="{Binding description}" Header="Question Description" />
                                    <DataGridTextColumn Binding="{Binding answer.id}" Header="Answer ID" />
                                    <DataGridTextColumn Binding="{Binding answer.description}" Header="Answer Description" />
                                    <DataGridTextColumn Binding="{Binding answer.isCorrect}" Header="Is Correct" />
                                    <DataGridTextColumn Binding="{Binding answer.pointAmount}" Header="Point Amount" />
                                </DataGrid.Columns>
                            </DataGrid>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
