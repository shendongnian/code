    foreach (var item in listBox.Items)
    {
        var sa = item.ToString().Split(',');
        if (sa.Length == 4)  //whatever it ought to be, optional sanity check
        {
            using (myNewSqlConnection)
            using (myNewSqlCommand)
            {
                //Data type is important here, so pay attention to that
                myNewSqlCommand.Parameters.Add("@par1", System.Data.DbType.String).Value = sa[0];  //@par1 would be in the SQL for parameterized query
               
               //Once you've added all of the values, execute the query.
            }
        }
    }
