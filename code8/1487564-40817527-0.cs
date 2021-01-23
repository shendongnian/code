    try
    {
    
        //Add columns selected
        List<string> Mycolumns = new List<string>();
        If (! string.IsNullOrEmpty(colnamedrop.Text)) Mycolumns.Add(colnamedrop.Text);
        If (! string.IsNullOrEmpty(colnamedrop2.Text)) Mycolumns.Add(colnamedrop2.Text);
        
        //Add values selected with escaped quoted and string quoted
        List<string> Myvalues ​​= new List<string>();
        If (! string.IsNullOrEmpty(colvalue1.Text)) Myvalues.Add("'" + colvalue1.Text.Replace("'", "''") + "'");
        If (! string.IsNullOrEmpty(colvalue2.Text)) Myvalues.Add("'" + colvalue2.Text.Replace("'", "''") + "'");
        
        //If nothing selected, no action
        if (Mycolumns.Count==0 && Myvalues.Count==0) return;
        
        //Build query
        String Query = string.Format ( "INSERT INTO {0} ({1}) VALUES ({2})", intodrop.Text, string.Join(Mycolumns, ", "), string.Join(Myvalues, ", "));
        //Execute query    
        using (var cmd = new SqlCommand(Query, con ))
        {
            con.Open();
    
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Record inserted");
            }
            else
            {
                MessageBox.Show("Record failed");
            }
    
            con.Close();
        }
    }
    catch (Exception g)
    {
        MessageBox.Show("Error during insert: " + g.Message);
    }
