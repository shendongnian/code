    private void btnCalcFahrenheit_Click(object sender, EventArgs e)
    {
        var fahrenheit = 9.0/5.0 * Convert.ToDouble(txtTemperature.Text) + 32.0;
        lblFahrenheit.Text = string.Format("{0:N0}", fahrenheit);
    }
    private void btnCalcCelsius_Click(object sender, EventArgs e)
    {
        var celsius = 5.0/9.0*(Convert.ToDouble(txtTemperature.Text) - 32.0);
        lblCelsius.Text = string.Format("{0:N0}", celsius);
    }
