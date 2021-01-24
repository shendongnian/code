     private void SingleSelectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.RemovedItems.OfType<PopolazioneCombo>())
            {
                item.Selected = false;
            }
            foreach (var item in e.AddedItems.OfType<PopolazioneCombo>())
            {
                item.Selected = true;
            }
        }
