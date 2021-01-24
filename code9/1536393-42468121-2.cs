    <DataGridTemplateColumn Header="ViewTemplate" Width="180">
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding ViewTemplate.Name}" />
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
        <DataGridTemplateColumn.CellEditingTemplate>
            <DataTemplate>
                <ComboBox ItemsSource="{Binding DataContext.ViewTemplates, RelativeSource={RelativeSource AncestorType=DataGrid}}"
                                          SelectedItem="{Binding ViewTemplate}"
                                          DisplayMemberPath="Name">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="SelectionChanged">
                            <cmd:EventToCommand PassEventArgsToCommand="True"
                                                                Command="{Binding DataContext.SelectionChangedCommand, RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </ComboBox>
            </DataTemplate>
        </DataGridTemplateColumn.CellEditingTemplate>
    </DataGridTemplateColumn>
