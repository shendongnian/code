    System.Collections.ObjectModel.ObservableCollection<a_autor> _sourceCollection;
    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        var erg = db.a_autor;
        erg.Load();
        _sourceCollection = new System.Collections.ObjectModel.ObservableCollection<a_autor>((from m in db.a_autor
                                                                                              orderby m.at_id
                                                                                              select m).ToList());
        box.ItemsSource = _sourceCollection;
    }
    private void loeschen_Click(object sender, RoutedEventArgs e)
    {
        a_autor am = (a_autor)box.SelectedItem;
        if (am != null)
        {
            _sourceCollection.Remove(am);
            db.a_autor.Remove(am);
            db.SaveChanges();
            box.Items.Refresh();
        }
    }
    private void neu_Click(object sender, RoutedEventArgs e)
    {
        a_autor autor = new a_autor();
        autor.at_id = id.Text;
        autor.at_vorname = vorname.Text;
        autor.at_nachname = nachname.Text;
        autor.at_gebDatum = Convert.ToDateTime(datum.Text);
        _sourceCollection.Add(autor);
        db.a_autor.Add(autor);
        box.Items.Refresh();
    }
