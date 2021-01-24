    double value;
    
    bool ok = double.TryParse(txt3Bimestre.Text, out value))
    
    if (ok)
    {
        txt3Bimestre.Text = value.ToString("0.00");
    }
    else
    {
        MessageBox.Show("Formato Inválido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txt3Bimestre.Clear();
        txt3Bimestre.Focus();
    }
