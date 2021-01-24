    public void DataGridRefresher()
        {
        condata = new MySqlConnection(cdata);
        cmgrid = new MySqlCommand("select * from liveriservis.teliko", condata);
        sda = new MySqlDataAdapter();
        sda.SelectCommand = cmgrid;
        dset = new DataTable();
        sda.Fill(dset);
        BindingSource bSource = new BindingSource();
        bSource.DataSource = dset;
        dataGridView1.DataSource = bSource;
        sda.Update(dset);
           }
