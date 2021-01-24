    void FillCombo()
        {
            SqlConnection conn = new SqlConnection(global::flight_management.Properties.Settings.Default.conn);
            string sql = "SELECT PortName FROM PORTS";
            SqlCommand exesql = new SqlCommand(sql, conn);
            SqlDataReader myReader;
           try
            {
                conn.Open();
                myReader = exesql.ExecuteReader();
                while(myReader.Read())
                {
                    string sName = myReader.GetString(0);
      //ust use the index 0 for first attribute in select list 
                    ComboFromA.Items.Add("sName");
                }
            }
    
            catch (Exception ex) {lblError.Text = "Error Loading Airports: "+ ex.Message;}
            finally {conn.Close();}
        }
