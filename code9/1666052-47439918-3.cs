    foreach (Control control in Controls.Cast<Control>()
        .Where(c => (c is Button || c is TextBox) &&
                    c.Name.Contains("Faixa")))
    {
        // Get the number associated with this control and compare it to numero_faixas
        int controlNumber;
        if (int.TryParse(control.Name.Substring(control.Name.Length - 1), out controlNumber) &&
            controlNumber < numero_faixas + 1)
        {
            control.Visible = true;
        }
    }
