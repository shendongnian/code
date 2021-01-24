    public DataTable GetDataTable(string QurStr)
    {
        DataTable dt = new DataTable();
        try
        {
            using (MySqlCommand cmd = new MySqlCommand(QurStr, Conn))
            using (MySqlDataReader dr = cmd.ExecuteReader())
            { 
               dt.Load(dr);
            }           
         }
         catch (Exception ex )
         {
            MessageBox.Show(ex.ToString()+ " \n DisplayDataGridView ");
         }
         return dt;
    }
