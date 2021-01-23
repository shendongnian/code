    public bool ParseandWarn(ref int Invoergetal1, ref int Invoergetal2){
    	bool valid = false;
    	if ((!int.TryParse(txtGetal1.Text, out Invoergetal1) || !int.TryParse(txtGetal2.Text, out Invoergetal2)) {
            MessageBox.Show("U dient een geheel getal in te voeren!", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;   
    }
    
    private void btnSom_Click(object sender, RoutedEventArgs e)
    {
    	int Invoergetal1, Invoergetal2;
        bool correctInput = ParseAndWarn(ref Invoergetal1, ref Invoergetal2);
        if(correctInput)
        {
           int BerekenSom = Invoergetal1 + Invoergetal2;
           txtResultaat.Text += "De som van " + txtGetal1.Text + " en " + txtGetal2.Text + " = " + BerekenSom + Environment.NewLine;
        }
    }
