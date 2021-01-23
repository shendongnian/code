    int totalNaams = 0;
    int totalConsumpties = 0;
    List<Klant> klanten = new List<Klant>();
    private void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
    {
        if (!IsNullOrEmpty(txtKlantConsumpties.Text.Trim()) && !IsNullOrEmpty(txtKlantNaam.Text.Trim()))
            if (totalConsumpties <= consumptiesMax)
            {
                lbOverzicht.Items.Add(new Klant
                    {
                        Naam = txtKlantNaam.Text,
                        Consumpties = int.Parse(txtKlantConsumpties.Text)
                    }
                );
        
                totalConsumpties += klanten.Consumpties;
                totalNaams += 0;
            }
        }
    }
