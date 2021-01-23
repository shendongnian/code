    int totalNaams = 0;
    int totalConsumpties = 0;
    int consumptiesTotalMax = 0;
    int consumptiesMax = 0;
    List<Klant> klanten = new List<Klant>();
    public class Klant
    {
        public string Naam { get; set; }
        public int Consumpties { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.Naam, this.Consumpties);
        }
    }
    public void btnKlantToevoegen_Click(object sender, RoutedEventArgs e)
    {
        int current = int.Parse(txtKlantConsumpties.Text);
        consumptiesTotalMax = int.Parse(txtTotalMax.Text);
        consumptiesMax = int.Parse(txtConsumpMax.Text);
        if (!string.IsNullOrEmpty(txtKlantConsumpties.Text.Trim()) && !string.IsNullOrEmpty(txtKlantNaam.Text.Trim()))
        {
            if (((totalConsumpties + current) <= consumptiesTotalMax) && (current <= consumptiesMax))
            {
                klanten.Add(new Klant
                    {
                        Naam = txtKlantNaam.Text,
                        Consumpties = current
                    }
                );
                lbOverzicht.ItemsSource = klanten;
                totalConsumpties += current;
                totalNaams += 1;
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lbOverzicht.ItemsSource);
                view.SortDescriptions.Add(new SortDescription("Naam", ListSortDirection.Ascending));
            }
        }
    }
