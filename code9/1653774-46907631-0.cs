    <DataGrid x:Name="Table" ItemsSource="{Binding AllBeams, UpdateSourceTrigger=Explicit}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridComboBoxColumn DisplayMemberPath="Name">
                <DataGridComboBoxColumn.ElementStyle>
                    <Style TargetType="{x:Type ComboBox}">
                        <Setter Property="ItemsSource" Value="{Binding Path=DataContext.AllBeams, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
                    </Style>
                </DataGridComboBoxColumn.ElementStyle>
                <DataGridComboBoxColumn.EditingElementStyle>
                    <Style TargetType="{x:Type ComboBox}">
                        <Setter Property="ItemsSource" Value="{Binding Path=DataContext.AllBeams, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" />
                    </Style>
                </DataGridComboBoxColumn.EditingElementStyle>
            </DataGridComboBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
