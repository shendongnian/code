    lblAerobicCap.Text = lblAerobicCap.Text.Trim();
    if (System.Text.RegularExpressions.Regex.IsMatch(lblAerobicCap.Text, "[^0-9]"))
    {
        MessageBox.Show("Im sorry, there seems to have been an error in the inputting of the readings, please restart the test");
    }
    [ ... ]
