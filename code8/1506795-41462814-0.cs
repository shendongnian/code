    private void rowAnagrafiche_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        DataGridRow row = sender as DataGridRow;
        if (row != null)
        {
            dynamic dataObject = row.DataContext;
            string nome = dataObject.nome;
        }
    }
