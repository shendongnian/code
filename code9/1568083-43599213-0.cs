        _con.Open();
        _con_trans = _con.BeginTransaction();
        using(SqlCommand cmd = _con.CreateCommand())
        {
            cmd.CommandText = "delete from XXXXX";
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = _con_trans;
            cmd.ExecuteNonquery();
        }
        using(SqlCommand cmd = _con.CreateCommand())
        {
            cmd.CommandText = "insert into XXXX";
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = _con_trans;
            cmd.ExecuteNonquery();
        }
        _con_trans.Commit();
        _con_trans = null;
        _con.Close();
