    <ComboBox ItemsSource="{Binding Vwr.Table.Tbl, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          x:Name="Supplier"
                          SelectedIndex="{Binding Vwr.Table.GridSelIndex, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          SelectedItem="{Binding Vwr.Table.Vals[1].Val, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                          IsEditable="True" 
                          Style="{StaticResource tabTextBox}"
                          DisplayMemberPath="Combined" TextSearch.TextPath="Combined">
    </ComboBox>
