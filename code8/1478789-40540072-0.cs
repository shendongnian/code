    if (NominalBox.Text != "")
    {
        int thresholdcas50;
        Int32.TryParse(NominalBox.Text, out thresholdcas50);
        koneksi.Open();
        System.Data.DataTable aksesdatatabel;
        aksesdatatabel = koneksi.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        koneksi.Close();
        OleDbCommand command = new OleDbCommand
        (
            "select Reject from [Sheet1$]", koneksi
        );
        DataSet coba = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        adapter.Fill(coba);
        // Just made a variable to quick identify your table.
        var table = coba.Tables[0];
        // Make a view from your table.
        var view = new DataView(table);
        // Make a filter on the view.
        view.RowFilter = string.Format("Reject > {0}", thresholdcas50);
        // Now set the DataSource to your filter.
        dataGridView1.DataSource = view;
    }
