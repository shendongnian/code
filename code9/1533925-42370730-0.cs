    <DataGridTextColumn Header="ColumnA" Binding="{Binding ProducerName, UpdateSourceTrigger=PropertyChanged}" IsReadOnly="True">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="dg_MouseLeftButtonDown" />
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
    
----------
    private void dg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridCell cell = sender as DataGridCell;
        dynamic dataObject = cell.DataContext;
        string producerName = dataObject.ProducerName;
        //do something...
    }
