    <DataGrid ItemsSource="{Binding BillingHistoryList}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding ar_bill_dt}">
                <DataGridTextColumn.Header>
                    <Button 
                        Content="Bill Date" 
                        Command="{Binding DataContext.SortData, RelativeSource={RelativeSource AncestorType=DataGrid}}" 
                        />
                </DataGridTextColumn.Header>
            </DataGridTextColumn>
            <DataGridTextColumn Header="Amount" Binding="{Binding ar_orig_amt}" />
            <DataGridTextColumn Header="Running Total" Binding="{Binding RunningTotal}" />
        </DataGrid.Columns>
    </DataGrid>
