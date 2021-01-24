    <DataGrid x:Name="dataGridArticles" AutoGenerateColumns="False" xmlns:local="clr-namespace:WpfApplication3">
        <DataGrid.Resources>
            <local:RowNumberConverter x:Key="RowNumberConverter" />
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="#" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding Converter="{StaticResource RowNumberConverter}">
                                    <Binding Path="." RelativeSource="{RelativeSource AncestorType=DataGridRow}" />
                                    <Binding Path="Items.Count" RelativeSource="{RelativeSource AncestorType=DataGrid}" />
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <!-- + the rest of your columns -->
        </DataGrid.Columns>
    </DataGrid>
