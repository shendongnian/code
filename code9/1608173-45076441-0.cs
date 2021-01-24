    <DataGrid Name="dgConfig" AutoGenerateColumns="False" ItemsSource="{Binding ModulesView}" >
     <DataGrid.Columns>
          <DataGridTextColumn Header="ParamName" Binding=" {Binding ParamName}" IsReadOnly="True"/>
          <DataGridTemplateColumn Header="ParamValues">
              <DataGridTemplateColumn.CellTemplate>                                                                 
                   <DataTemplate>                                                           
                       <ComboBox ItemsSource="{Binding ParamValues}" SelectedItem="{Binding DefaultValue, Mode=TwoWay}" SelectedValuePath="ParamValues" SelectedValue="{Binding ParamValues,Mode=TwoWay}" />
                   </DataTemplate>
              </DataGridTemplateColumn.CellTemplate>                                                           
         </DataGridTemplateColumn>
         <DataGridTextColumn Header="DefaultValue" Binding="{Binding DefaultValue}" IsReadOnly="True"/>
     </DataGrid.Columns>
