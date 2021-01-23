    DataTable dsDetalle=new DataTable("Data");           
    using (MySqlCommand commandSql = cn.CreateCommand())
    {
        commandSql.CommandType = CommandType.Text;
        commandSql.CommandText = "select * from detalle where iddetalle=@iddetalle and idlocal=@idlocal";
        commandSql.Parameters.AddWithValue("@iddetalle", "txt_boleta.Text");
        commandSql.Parameters.AddWithValue("@idlocal", "txtlocal.Text");
        MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(commandSql);
        sqlAdapter.Fill(dsDetalle);
    }
    GridView1.DataSource = dsDetalle;
    GridView1.DataBind();
