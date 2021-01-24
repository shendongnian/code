    private void txtFahrenheit_TextChanged(object sender, EventArgs e)
    {
        if (!programIsUpdatingProperties)
        {
            int fahrValue;
            // Use int.TryParse to ensure it's a valid integer (if it's not, do nothing)
            if (int.TryParse(txtFahrenheit.Text, out fahrValue))
            {
                UpdateTempFields(fahrValue);
            }
        }
    }
    private void txtCelsius_TextChanged(object sender, EventArgs e)
    {
        if (!programIsUpdatingProperties)
        {
            int celsiusValue;
            // Use int.TryParse to ensure it's a valid integer (if it's not, do nothing)
            if (int.TryParse(txtCelsius.Text, out celsiusValue))
            {
                // Convert celcius to fahrenheit first
                var fahrValue = GetFahrenheitValue(celsiusValue);
                UpdateTempFields(fahrValue);
            }
        }
    }
    private void hsbTemperature_ValueChanged(object sender, EventArgs e)
    {
        if (!programIsUpdatingProperties)
        {
            UpdateTempFields(hsbTemperature.Value);
        }
    }
