    private void btnCalculate_Click(object sender, EventArgs e)
    {
        //Validate the cost
        if (Double.TryParse(txtCost.Text, out double dblTuition)) {
            if (dblTuition > 0) {
                DisplayTheTuition(dblTuition);
            } else {
                DisplayMessageAndResetCost("Invalid Input, Cost Needs to be Greater than Zero.");
            }
        } else {
            DisplayMessageAndResetCost("Invalid input for Cost.");
        }
        txtCost.Focus();
        txtCost.SelectAll();
    }
    private void DisplayTheTuition(double dblTuition)
    {
        const int NumberOfCreditsToDisplay = 18;
        lstTuition.Items.Clear();
        for (int x = 1; x <= NumberOfCreditsToDisplay; x++) {
            lstTuition.Items.Add($"{x} Credits ~ {x * dblTuition:c}");
        }
    }
    private void DisplayMessageAndResetCost(string message)
    {
        MessageBox.Show(message);
        txtCost.Text = String.Empty;
    }
