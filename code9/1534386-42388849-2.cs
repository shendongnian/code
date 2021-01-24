    <DataGrid DataContext="{Binding}" ItemsSource="{Binding Models}" AutoGenerateColumns="False">
        <DataGrid.Resources>
            <local:conv1 x:Key="conv1" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn>
                <DataGridTextColumn.Binding>
                    <MultiBinding Converter="{StaticResource conv1}">
                        <Binding />
                        <Binding Path="DataContext.SelectedItem" RelativeSource="{RelativeSource AncestorType=DataGrid, Mode=FindAncestor}" />
                    </MultiBinding>
                </DataGridTextColumn.Binding>
                <DataGridTextColumn.Header>
                    <ComboBox DataContext="{Binding Path=DataContext, RelativeSource={RelativeSource AncestorType=DataGrid, Mode=FindAncestor}}" 
                              ItemsSource="{Binding Items}" SelectedItem ="{Binding SelectedItem, Mode=TwoWay}"/>
                </DataGridTextColumn.Header>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
