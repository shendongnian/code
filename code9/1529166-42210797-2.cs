    private void button19_Click(object sender, EventArgs e)  
    {
        if (isDecimal)
        {
            txtResult.Text = ".";
            isDecimal = true;
            creatingNewNumber = true;
        }
        txtResult.Text += "."; // should add one more decimal point 
    }
