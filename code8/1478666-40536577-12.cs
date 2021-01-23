    int totalNaams = 0;
    int totalConsumpties = 0;
    int consumptiesTotalMax = int.Parse(txtTotalMax.Text);
    int consumptiesMax = int.Parse(txtConsumpMax.Text);
    public void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
        {
            int current = int.Parse(txtKlantConsumpties.Text);
            if (!string.IsNullOrEmpty(txtKlantConsumpties.Text.Trim()) && !string.IsNullOrEmpty(txtKlantNaam.Text.Trim()))
            {
                if ((totalConsumpties <= consumptiesTotalMax) && (current <= consumptiesMax))
                {
                    Klant klanten = new Klant
                    {
                        Naam = txtKlantNaam.Text,
                        Consumpties = current
                    };
                    lbOverzicht.Items.Add(klanten);
                    totalConsumpties += klanten.Consumpties;
                    totalNaams += 0;
                    lbOverzicht.Items.SortDescriptions.Add(new SortDescription("", ListSortDirection.Ascending));
                }
            }
        }
