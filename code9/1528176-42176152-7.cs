     <DataGrid >
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding}" >
                    <DataGridTextColumn.HeaderTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <TextBox Text="{Binding DataContext.Name, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
                                <CheckBox IsChecked="{Binding DataContext.Value , RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                                <ComboBox ItemsSource="{Binding DataContext.Names , RelativeSource={RelativeSource AncestorType=DataGrid}}" SelectedIndex="0"/>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTextColumn.HeaderTemplate>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
