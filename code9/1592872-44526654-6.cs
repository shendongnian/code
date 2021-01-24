    private void SingleSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (var item in e.RemovedItems.OfType<PopolazioneCombo>())
        {
            item.Selezionato = false;
        }
        foreach (var item in e.AddedItems.OfType<PopolazioneCombo>())
        {
            item.Selezionato = true;
        }
    }
