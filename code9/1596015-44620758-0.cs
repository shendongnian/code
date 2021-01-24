    private void comboBox1_nume_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1_nume.SelectedIndex != -1)
        {
            AbonatTelefonic at = (AbonatTelefonic)listaAbonati[comboBox1_nume.SelectedIndex];
            MessageBox.Show(at.YourAttribute);
        }
    }
