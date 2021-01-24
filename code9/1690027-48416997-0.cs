      public static void BulkCopy(string connectionString, DataTable dataTableToSend, string SQLTableName)
            {
                SqlConnection connexion = null;
    
                try
                {
                    connexion = new SqlConnection(connectionString);
                    BulkCopy(connexion, dataTableToSend, SQLTableName);
                }
                catch (Exception e)
                {
                    
                    throw;
                }
                finally
                {
                    connexion?.Close();
                    connexion?.Dispose();
                }
            }
    
    int Modulo=0;
     
    //Create a datatable MyDataTable with same structure of your table in database
    // you can do : select * from MyTable where 1<>1 with command for get structured dataset (and datatable)
    
     
     using (System.IO.StreamReader file = new System.IO.StreamReader(fileName, Encoding.UTF8))
     {
         while ((Line = file.ReadLine()) != null)
         {
             counter++;
     
             DataRow newrow = MyDataTable.NewRow();
     
     
             //Set value
             newrow["I_ID"] = counter;
             newrow["L_NomFichier"] = FileObj.Name;
             newrow["D_CreationFichier"] = FileObj.LastWriteTime;
             newrow["L_Ligne"] = Line.DBNullIfNullOrEmpty();
             newrow["D_DATCRE"] = newrow["D_DATMAJ"] = DateTime.Now;
             newrow["C_UTICRE"] = newrow["C_UTIMAJ"] = GlobalParam.User;
     
             MyDataTable.Rows.Add(newrow);
     
     
             if (Modulo % 1000)
             {
             SqlHelper.BulkCopy(DBAccess.CONN_STRING, MyDataTable, "YOURTABLENAME");
     
             MyDataTable.Rows.Clear();
     
             }
     
             
         }
     
         SqlHelper.BulkCopy(DBAccess.CONN_STRING, MyDataTable, "YOURTABLENAME");
     
         MyDataTable.Rows.Clear();
     
         file.Close();
     }
