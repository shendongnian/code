    private void button1_Click_1(object sender, EventArgs e)
    {
        int antal= Integer.Parse(tbxDeci.Text); // tbxDeci is the textbox where they write how many decimals that will be used
        double svar = Double.Parse(lblSvar.Text);  //  lblSvar is the label where the answer would display, in our case the 0,333...
        double deci = Math.Round(svar, antal);
        lblSvar.Text = deci.ToString();
    }
