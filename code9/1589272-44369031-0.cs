    class DataAdapter
    {
        public void UpdateLeads(LeadsInfo info)
        {
            using (MySqlConnection cn = new MySqlConnection(ConString))
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "UPDATE Leads SET CVR = ('" + info.CVR + "'), Firma = ('" + info.Firma + "')," /* ... */;
                cmd.ExecuteNonQuery();    
                cmd.Dispose();
                cn.Close();
            } 
        }
    }
