    public static void MoveLead(RadGridView Gridview, RadDropDownList SegmentDropdown, string UniqueID)
    {
        try
        {
            string Table = SegmentDropdown.Text;
            using (MySqlConnection cn = new MySqlConnection(Varribles.ConString))
            {
                string query = "select max(UniqueID) from Callbacks;";
                cn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    // Notice I removed the command text, you are already setting the command text in the constructor for the MySqlCommand
                    int UID = Int32.Parse(cmd.ExecuteScalar());
                    Console.WriteLine("quey" + UID);
                }
            }
            using (MySqlConnection cn = new MySqlConnection(Varribles.ConString))
            {
                string query = "BEGIN;  INSERT INTO Callbacks select * from ?Table where UniqueID = ?UniqueID; DELETE FROM ?Table where UniqueID = ?UniqueID; COMMIT;";
                cn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    // Use parameters to sanitize input. There are very rare circumstances where you would want to do a direct concatenation to a query as its susceptible to sql injection
                    cmd.Parameters.Add(new MySqlParameter("Table", Table))
                    cmd.Parameters.Add(new MySqlParameter("UniqueID", UniqueID))
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
