        <DataGrid ItemsSource="{Binding Path=Teams}"
          AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Team" 
                                    IsReadOnly="True"
                                    Width="*"
                                     Binding="{Binding Name}" />
                <DataGridComboBoxColumn Header="Members" 
                                        Width="*"
                                        >
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=Members}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=Members}" />
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
