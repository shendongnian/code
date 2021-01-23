    public bool ParseandWarn()
    {
        int Invoergetal1, Invoergetal2;
        if (!int.TryParse(txtGetal1.Text, out Invoergetal1) || !int.TryParse(txtGetal2.Text, out Invoergetal2)
        {
            MessageBox.Show("U dient een geheel getal in te voeren!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;   
    }
    private void btnSom_Click(object sender, RoutedEventArgs e)
    {
        bool correctInput = ParseAndWarn();
        if(correctInput)
        {
           int BerekenSom = int.Parse(txtGetal1.Text) + int.Parse(txtGetal2.Text);
           txtResultaat.Text += "De som van " + txtGetal1.Text + " en " + txtGetal2.Text + " = " + BerekenSom + Environment.NewLine;
        }
    }
