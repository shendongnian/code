    // Create SqlConnection 
           SqlConnection conn= new SqlConnection(@"Server=server_name; 
         DataBase=your_data_base_name;Integrated Security=false;User 
           Id=user_id;Password=password");
        // Open the Connection 
	if (sqlconnection.State != ConnectionState.Open)
            {
                conn= .Open();
            }
	// execute stored_procedure method don't change this 
	public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcomd = new SqlCommand();
            sqlcomd.CommandType = CommandType.StoredProcedure;
            sqlcomd.CommandText = stored_procedure;
            sqlcomd.Connection = sqlconnection;
            if (param !=null)
            {
                sqlcomd.Parameters.AddRange(param);
            }
            sqlcomd.ExecuteNonQuery();
        }
          // close connection method
          public void close_conn()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }      
           // execute and retrieving data Method	
        public void Add_product(int ID_cat ,string Name_Product,string 
         Des_Product)
        {
           SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_cat;
            param[1] = new SqlParameter("@NAME_PRODUCT", SqlDbType.VarChar, 50);
            param[1].Value = Name_Product;
            param[2] = new SqlParameter("@DESC_PRODUCT", SqlDbType.VarChar, 50);
            param[2].Value = Des_Product;  
       
            ExecuteCommand("StoredProcedure_name", param);
            close_conn();
          }
