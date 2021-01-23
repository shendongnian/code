    <DataGrid x:Name="tcgrid" ItemsSource="{Binding tcc, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                      AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding AGNR.Value, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" 
                                    Header="{Binding AGNR.Key, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"/>
            <DataGridTextColumn Binding="{Binding MNR.Value, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" 
                                    Header="{Binding MNR.Key, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"/>
            <DataGridTextColumn Binding="{Binding MST.Value, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" 
                                    Header="{Binding MST.Key, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}"/>
        </DataGrid.Columns>
    </DataGrid>
