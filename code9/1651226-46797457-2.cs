    private bool txtAvgRHasChangedFlag;
    private bool txtOTRRHasChangedFlag;
    // TextChangedEventHandler delegate method.
    private void textChangedEventHandler(object sender, TextChangedEventArgs args)
    {        
        var control = sender as TextBox;
        
        if (control.Name == "txtAvgR")
            txtAvgRHasChangedFlag = true;
        else if (control.Name == "txtOTR")
            txtOTRHasChangedFlag = true;
    }
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        if (txtAvgRHasChangedFlag)
        {
            oldAvgRate = UpdateRate(dfAvgR.SelectedDate.Value.ToString("yyyy-MM-dd"), txtAvgR.Text, oldAvgRate, ratetype, txtdescriptionAvgR.Text);
            MessageBox.Show("Done", "Test", MessageBoxButton.OK);
        }
        if (txtOTRRHasChangedFlag)
        {
            oldOTRate = UpdateRate(dfOTR.SelectedDate.Value.ToString("yyyy-MM-dd"), txtOTR.Text, oldOTRate, ratetypeOT, txtdescriptionOTR.Text);
            MessageBox.Show("Done", "Test", MessageBoxButton.OK);
        }
        if (!txtOTRRHasChangedFlag && !txtAvgRHasChangedFlag)
        {    
            MessageBox.Show("Nothing has changed", "Test", MessageBoxButton.OK);
            return;
        }
    }
