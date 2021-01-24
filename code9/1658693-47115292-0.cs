    string sql= "UPDATE Kunden "+
    " SET value1='?value1' WHERE ID=1";
    try
    {
      con.Open();
      cmd=new MySqlCommand(sql,con);
      cmd.Parameters.Add(new MySqlParameter("value1",value1.Text));
      //and for every parameter you need like Game,Bezahlt,Kundenname add a new
      //cmd.Paramaters.Add(new MySqlParameter("paramName",paramValue));
    }
    catch(MySqlException ex)
    {
       MessageBox.Show(ex.Message);
    }
