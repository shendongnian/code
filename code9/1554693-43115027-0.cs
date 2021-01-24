    private void cargarListaAgenda(List<listaAgendaClass> lista)
    {
        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
        {
            gridAgendaDataGridAgenda.AutoGeneratingColumn -= GridAgendaDataGridAgenda_AutoGeneratingColumn;
            gridAgendaDataGridAgenda.AutoGeneratingColumn += GridAgendaDataGridAgenda_AutoGeneratingColumn;
            gridAgendaDataGridAgenda.ItemsSource = lista;
        }));
    }
    private void GridAgendaDataGridAgenda_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        e.Column.Visibility = Visibility.Hidden;
        if (e.Column.Header.ToString() == "Nombre" || e.Column.Header.ToString() == "Alias" || e.Column.Header.ToString() == "Apellidos")
        {
            e.Column.Visibility = Visibility.Visible;
            if (e.Column.Header.ToString() != "Apellidos")
                e.Column.Width = new DataGridLength(gridAgendaDataGridAgenda.Width * 0.33);
            else
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
    }
