    private bool _isCalculating = false;
	
	private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _isCalculating = true;
    
        ComboBox s = (ComboBox)e.Source;
        vmEinnahme.CalculateBetrag((int)enumBetColIndex.UstSatz);
    
        _isCalculating = false;
		
        e.Handled = true;
    }
    
    private void Betrag_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if(!_isCalculating)
		{
            vmEinnahme.CalculateBetrag(e.Column.DisplayIndex);
		}
    }
