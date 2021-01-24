    private void buttonCalculate_Click(object sender, EventArgs e) 
    {
        double val1 = double.Parse(AngabeGesamt.Text);
        double val2 = double.Parse(AngabeStärke.Text);
        double result = val1 / 20 * val2;
        labelBase.Text = result.ToString();
    }
