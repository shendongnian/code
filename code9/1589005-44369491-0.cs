    public void btn_load_Click(object sender, RoutedEventArgs e)
    {
        MainWindow M = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        ArtikelLaden(M);
        M.RefreshGrid();
        Close();
    }
    public void ArtikelLaden(MainWindow M)
    {
        rowindexArtikel = dg_Artikel.SelectedIndex;
        Artikel B = new Artikel();
        B = artikelList[rowindexArtikel];
        M.loadArtikel(B);
    }
