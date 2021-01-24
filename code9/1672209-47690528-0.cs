    <DataGrid Margin="8" Style="{StaticResource CoDeDataGrid}" ItemsSource="{Binding Path=TableDataGridView}" 
              AutoGenerateColumns="False" IsReadOnly="True" Name="AxisGrid">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Name}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding DataContext.Coordinatesystem, 
                          Converter={StaticResource EnumToDisplayTextConverter} , RelativeSource={RelativeSource AncestorType=DataGrid}}"/>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            ...
            <DataGridTemplateColumn>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Style="{StaticResource CoDeButtonSmall}"
                           Command="{Binding  Path=DataContext.OnSetReferenceCommand, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" 
                           CommandParameter="{Binding ElementName=AxisGrid, Path=SelectedItem}"
                           Visibility="{Binding Name, Converter={StaticResource ButtonNameToVisibilityConverter}, ConverterParameter={DataContext.TeachAxis}">
                            <Image Source="C:\Users\PA\Source\Repos\Source\Common.Resources\ImageResources\TestPicture.jpg" Height="24" Width="24"/>
                        </Button>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
