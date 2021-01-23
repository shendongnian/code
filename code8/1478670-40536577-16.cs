    int totalNaams = 0;
    int totalConsumpties = 0;
    int consumptiesTotalMax = 0;
    int consumptiesMax = 0;
    public void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
        {
            int current = int.Parse(txtKlantConsumpties.Text);
            consumptiesTotalMax = int.Parse(txtTotalMax.Text);
            consumptiesMax = int.Parse(txtConsumpMax.Text);
            if (!string.IsNullOrEmpty(txtKlantConsumpties.Text.Trim()) && !string.IsNullOrEmpty(txtKlantNaam.Text.Trim()))
            {
                if (((totalConsumpties + current) <= consumptiesTotalMax) && (current <= consumptiesMax))
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
