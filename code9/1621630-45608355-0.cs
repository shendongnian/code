    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        dgvBetraege.CellEditEnding -= Betrag_CellEditEnding;
    
        ComboBox s = (ComboBox)e.Source;
        vmEinnahme.CalculateBetrag((int)enumBetColIndex.UstSatz);
    
        dgvBetraege.CellEditEnding += Betrag_CellEditEnding;
        e.Handled = true;
    }
    
    private void Betrag_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        dgvBetraege.CellEditEnding -= Betrag_CellEditEnding;
    
        vmEinnahme.CalculateBetrag(e.Column.DisplayIndex);
    
        dgvBetraege.CellEditEnding += Betrag_CellEditEnding;
    }
