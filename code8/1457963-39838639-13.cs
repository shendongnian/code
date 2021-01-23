    <DataGrid IsReadOnly="False" AutoGenerateColumns="False">
       <DataGrid.ItemsSource>
        <MultiBinding Converter="{StaticResource MyObjectCollectionDataGridConverter}" UpdateSourceTrigger="PropertyChanged">
            <Binding Path="StateManager.MyObjectCollection" Mode="TwoWay"/>
            <Binding Mode="OneWay"/>
        </MultiBinding>
       </DataGrid.ItemsSource>
       <DataGrid.Columns>
              <DataGridTemplateColumn>
                  <DataGridTemplateColumn.CellTemplate>
                      <DataTemplate>
                          <TextBox Text="Hello" IsEnabled="{Binding IsEnabled}"/>
                      </DataTemplate>
                  </DataGridTemplateColumn.CellTemplate>
              </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
