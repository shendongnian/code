        using (OleDbConnection thisConnection = new OleDbConnection(connectionname))
        {
            
     string cmdStr = "Select count(*) from SFModelOutputVariables WHERE [Entity] = '" + ENTITY + "'"; 
     OleDbCommand cmd = new      OleDbCommand(cmdStr, thisConnection);
       int count = (int)cmd.ExecuteScalar();
       if(count == 0)
       {
             MessageBox.Show("Sorry no entity was found :-(");
                return;
       }
       // write your code for removing things here....
     }
