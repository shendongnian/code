    for (int i = 0; i < Dt_AllPage.Rows.Count; i++)
           {
               Model_name = Dt_AllPage.Rows[i][0].ToString();
    
               DataSet Ds_SelectTBlRAM = DAL.SelectTBlRAM();
               DataTable Dt_SelectTBlRAM = Ds_SelectTBlRAM.Tables[0];
    
    
               DataRow row1 = Dt_SelectTBlRAM.AsEnumerable().FirstOrDefault(r => r.Field<string>("SKU").Contains(Model_name));
               foreach (DataRow row2 in Dt_SelectTBlRAM.Rows)
               {
                   if (row1 != null)
                   {
                       int Model_ID = (from DataRow DR in Dt_SelectTBlRAM.Rows
                                       where (string)DR["SKU"] == Model_name
                                       select (int)DR["ID"]).FirstOrDefault();
                   }
    
               }
    
    
    
               string Price = Dt_AllPage.Rows[i][1].ToString();
               Model_name = Dt_AllPage.Rows[i][0].ToString();
    
           }
