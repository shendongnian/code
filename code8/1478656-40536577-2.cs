    int totalNaams = 0;
    int totalConsumpties = 0;
    List<Klant> klanten = new List<Klant>();
    private void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
    {
        if (totalConsumpties <= consumptiesMax)
        {
            klanten.Add(new Klant
                {
                    Naam = txtKlantNaam.Text,
                    Consumpties = int.Parse(txtKlantConsumpties.Text)
                }
            );
        
            totalConsumpties += klanten.Consumpties;
            totalNaams += 0;
            for (int i = 0; i < klanten.Count; i++)
            {
                lbOverzicht.Items.Add(klanten[i]);
            }
        }
    }
