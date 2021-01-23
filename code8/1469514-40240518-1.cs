        private void InsertDynamicColumn(string source, string destination)
        {
            //dt from Session
            DataTable dt = new DataTable();
            dt = (DataTable)Session["myData"];
            //list filtered by Column name
            var list = from t in dt.AsEnumerable()
                           select new
                           {
                               colX = t.Field<string>(destination),// "ColX"
                           };
            //new filtered list.
            var listOfColx = list.ToList();
            //loop through list and insert values to source from parameters
            for (int i = 0; i < listOfColx.Count; i++)
            {
                connection();
                strsql = string.Format("Insert into F3_BC_Product_Mapping_Data ({0}) values (@value) ", source);
                cmd = new SqlCommand(strsql, con);
                cmd.Parameters.AddWithValue("@value", listOfColx[i]);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
    
            }
        }
