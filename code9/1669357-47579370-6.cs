    private void btnCalculate_Click(object sender, EventArgs e)
    {
        //Validate the cost
        if (Double.TryParse(txtCost.Text, out double dblTuition)) {
            if (dblTuition > 0) {
                const int NumberOfCreditsToDisplay = 18;
                //display the tuition
                lstTuition.Items.Clear();
                for (int x = 1; x <= NumberOfCreditsToDisplay; x++) {
                    lstTuition.Items.Add($"{x} Credits ~ {x * dblTuition:c}");
                }
            } else {
                //Display an error message for the cost textbox
                MessageBox.Show("Invalid Input, Cost Needs to be Greater than Zero.");
                //Set the cost to zero
                txtCost.Text = String.Empty;
            }
        } else {
            //Display an error message for the Cost textbox
            MessageBox.Show("Invalid input for Cost.");
            //Set the cost to zero
            txtCost.Text = String.Empty;
        }
        txtCost.Focus();
        txtCost.SelectAll();
    }
