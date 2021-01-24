    private void button1_Click_1(object sender, EventArgs e)
    {
        int antal= int.Parse(tbxDeci.Text);
        double svar = double.Parse(txtSvar.Text);
        // Above, txtSvar is a TextBox to which the value you want to round off is entered.
        double deci = Math.Round(svar, antal);
        lblSvar.Text = deci.ToString();
    }
