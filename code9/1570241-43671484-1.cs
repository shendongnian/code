    private void UpdateTempFields(int newFahrenheitTemp)
    {
        // Let the rest of the code know this is us, not the user
        programIsUpdatingProperties = true;
        TempFah = newFahrenheitTemp;
        TempCel = GetCelciusValue(TempFah);
        txtCelsius.Text = TempCel.ToString();
        txtFahrenheit.Text = TempFah.ToString();
            
        // Ensure we don't try to set the scroll bar to a value it can't handle
        hsbTemperature.Value =
            Math.Max(hsbTemperature.Minimum,
                Math.Min(hsbTemperature.Maximum, TempFah));
        // Carry on as normal now...
        programIsUpdatingProperties = false;
    }
