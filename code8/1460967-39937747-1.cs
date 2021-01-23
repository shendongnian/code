	 public static DataTable Query1()
        {
		   // why this variable returnvalue, you don't fill it
            List<string[]> returnvalue = new List<string[]>(); 
            //check the connection with database by using DatabaseConnection.OpenConnection() only once, and using the property Connect
            if (DatabaseConnection.connect.State == ConnectionState.Closed)
                DatabaseConnection.OpenConnection();
            DataTable tbl = new DataTable(); //use it as a return value
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM UniqueWeapon U, Weapon W WHERE W.WeaponID = U.WeaponIDFK AND U.AllyIDFK IS NOT NULL AND W.Damage > 10 AND W.WeaponType = 'Spell';", DatabaseConnection.connect);
              
                cmd.Connection = DatabaseConnection.connect; //connect is SQlConnection
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                //DataTable tbl = new DataTable(); //use it as a return value
                dap.Fill(tbl);
                Debug.WriteLine(tbl.Rows.Count);
                //cmd.CommandText = "SELECT * FROM UniqueWeapon U, Weapon W WHERE W.WeaponID = U.WeaponIDFK AND U.AllyIDFK IS NOT NULL AND W.Damage > 10 AND W.WeaponType = 'Spell';";
                //cmd.ExecuteNonQuery();             
                //why that code, you already filled the table using SqlDataAdapter
                //SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    dap.Fill(tbl);
                //}
                // but if you want to fill datatable from Datareader use: tbl.Load(reader)
            }
            catch (SqlException e)
            {
                Console.WriteLine("Query Failed: " + e.StackTrace + e.Message.ToString());
                //return "returnvalue";
            }
            finally
            {
                DatabaseConnection.CloseConnection();
            }
            //return "returnvalue";
            return tbl;
        }
		
