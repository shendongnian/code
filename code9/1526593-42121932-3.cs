    <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False" HeadersVisibility="None" CanUserAddRows="False"
                          xmlns:local="clr-namespace:WpfApplication1">
        <DataGrid.Resources>
            <local:RowHeightConverter x:Key="conv" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Path=Col1}" Width="*"/>
            <DataGridTemplateColumn Width="*">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <DataGrid ItemsSource="{Binding Path=Col2}" AutoGenerateColumns="False" HeadersVisibility="None" CanUserAddRows="False">
                            <DataGrid.ItemContainerStyle>
                                <Style TargetType="DataGridRow">
                                    <Setter Property="Height" Value="{Binding Path=., RelativeSource={RelativeSource AncestorType=DataGrid}, 
                                                    Converter={StaticResource conv}}" />
                                </Style>
                            </DataGrid.ItemContainerStyle>
                            <DataGrid.Columns>
                                <DataGridTextColumn Binding="{Binding}" Width="*"/>
                            </DataGrid.Columns>
                        </DataGrid>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
