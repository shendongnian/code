        private void comboBoxEstilo_SelectedIndexChanged(object sender, EventArgs e)
        {
             int tamanho = int.Parse(comboBoxTamanho.Text);
    
             ComboBox comboBox = (ComboBox)sender;
             string selectedEstilio = (string) comboBox.SelectedItem;
             richTextBoxTexto.SelectionFont = new Font(comboBoxTipo.SelectedItem.ToString(), tamanho, selectedEstilio);
        }
