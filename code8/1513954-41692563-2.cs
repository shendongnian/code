    using(var con=new SqlConnection(myConnectionString))
    {
        _myGridAdapter.SelectCommand.Connection=con;
        _myGridAdapter.SelectCommand.Parameters["@name"].Value =....;
        con.Open();
        var dt = new DataTable();
        _myGridAdapter.Fill(dt);
        dtgrdView.DataSource = dt;
        return dtgrdView;
    }
