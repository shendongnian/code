    var rowFieldComparer = DataRowComparer.Default;
    for(int i = 0; i < FichierSource.DTSource.Rows.Count; i++)
    {
        if (rowFieldComparer.Equals(FichierSource.DTSource.Rows[i], FichierSource.DTBanque.Rows[i]))
            MessageBox.Show("Same");
        else
            MessageBox.Show("Not the same");
    }
