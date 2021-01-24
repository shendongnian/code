    <DataGridTemplateColumn Header="CustomCell">
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <ComboBox ItemsSource="{Binding Source={x:Static local:ViewModel.PossibleComponentMeasurementApprovements}}"
                            DisplayMemberPath="ApprovementText"
                            SelectedItem="{Binding Approvement}">
                    <ComboBox.ItemContainerStyle>
                        <Style TargetType="{x:Type ComboBoxItem}">
                            <Setter Property="IsEnabled" Value="{Binding Enabled}"/>
                        </Style>
                    </ComboBox.ItemContainerStyle>
                </ComboBox>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
