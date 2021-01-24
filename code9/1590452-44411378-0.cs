    private void radioButtondinner_CheckedChanged(object sender, EventArgs e)
            {
                if (!radioButtondinner.Checked)
                {
                    // if you want to clear only the text or selected item text
                    comboBoxdinner.Text = String.Empty;
                    // if you want to clear the entire data source
                    comboBoxdinner.DataSource = null;
                }
    
            }
