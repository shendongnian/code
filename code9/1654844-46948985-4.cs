     string conn = "Server=EGC25199;Initial Catalog=LegOgSpass;Integrated Security=True";
     string query = "sampleone";
            DataTable dt = new DataTable();
     SqlConnection connDatabase = new SqlConnection(conn);
     connDatabase.Open();
     //string query = "insert into [Source].[Table] (Name,Description,LogicalLayerID,SchemaFK) values (@sourcetable,null,null,null)";
     SqlCommand cmd = new SqlCommand(query, connDatabase);
            using (var da = new SqlDataAdapter(cmd)) 
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@createdOn", SqlDbType.Date).Value = "2017-10-10"; //Adding the selected items to parameter @check
                cmd.ExecuteNonQuery();
                da.Fill(dt);
               
                foreach( DataRow row in dt.Rows)
                {
                    Console.WriteLine();
                    for (int x = 0; x < dt.Columns.Count; x++)
                    {
                        Console.Write(row[x].ToString() + " ");
                    }
                }
            }
           
            connDatabase.Close();
