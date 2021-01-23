    int totalNaams = 0;
    int totalConsumpties = 0;
    int consumptiesTotalMax = 20
    int consumptiesMax = 3;
    List<Klant> klanten = new List<Klant>();
    private void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
    {
        int current = int.Parse(txtKlantConsumpties.Text);
        if (!IsNullOrEmpty(txtKlantConsumpties.Text.Trim()) && !IsNullOrEmpty(txtKlantNaam.Text.Trim()))
        {
            if ((totalConsumpties <= consumptiesTotalMax) && (current <= consumptiesMax))
            {
                lbOverzicht.Items.Add(new Klant
                    {
                        Naam = txtKlantNaam.Text,
                        Consumpties = current
                    }
                );
        
                totalConsumpties += klanten.Consumpties;
                totalNaams += 0;
            }
        }
    }
